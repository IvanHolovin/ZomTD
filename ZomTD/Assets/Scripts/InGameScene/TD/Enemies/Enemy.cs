using System;
using InGameScene.TD.TDGamePlay;
using UnityEngine;
using UnityEngine.AI;

namespace InGameScene.TD.Enemies
{
    public enum EnemyType
    {
        ZombieWalker,
        HugeZombie
    }
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] 
        private EnemyScriptableObj _enemyData;

        [SerializeField] 
        private ZombieAggroTrigger _trigger;
        
        public Transform targetPoint;
        
        public EnemyFactory OriginFactory { get; set; }
        
        public SpawnManager OriginSpawner { get; set; }

        private NavMeshAgent _navMeshAgent;

        private GameObject _destinationPoint;
        
        private float _moveSpeed;
        
        private bool _slowed;
        
        private float _health;

        private bool _resetedDestination = true;

        private void Awake()
        {
            _health = _enemyData.Health;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _moveSpeed = _navMeshAgent.speed;
        }

        private void Update()
        {
            if (_trigger.Following)
            {
                _navMeshAgent.destination = _trigger.FollowPlayer().transform.position;
                _resetedDestination = false;
            }
            else if (!_trigger.Following && !_resetedDestination)
            {
                Debug.Log("nav mesh update");
                _navMeshAgent.destination = _destinationPoint.transform.position;
                _resetedDestination = true;
            }
        }

        public EnemyType EnemyType
        {
            get => _enemyData.EnemyType;
        }

        public void TakeDamage(float damage)
        {
            if (_health - damage > 0)
            {
                _health -= damage;
            }
            else
            {
                Die();
            }
        }

        public void TakeSlow(float slowRate)
        {
            if (_enemyData.CanSlowDown)
            {
                if (!_slowed)
                {
                    _navMeshAgent.speed -= _navMeshAgent.speed * slowRate / 100;
                    _slowed = true;
                }
                else
                {
                    if ((_moveSpeed - _moveSpeed * slowRate / 100) < _navMeshAgent.speed)
                    {
                        _navMeshAgent.speed = _moveSpeed - _moveSpeed * slowRate / 100;
                    }
                }
            }
        }

        public void SetDestination(GameObject endPoint)
        {
            _destinationPoint = endPoint;
            _navMeshAgent.destination = _destinationPoint.transform.position;
        }
        
        public void RemoveSlow()
        {
            _navMeshAgent.speed = _moveSpeed;
            _slowed = false;
        }

        public float EndPointReach()
        {
            OriginSpawner.UnRegisterEnemy(this);
            OriginFactory.Reclaim(this);
            return _enemyData.DamageToEndPoint;
        }
        
        protected virtual void Die()
        {
            MoneyIncomeDispatcher.Instance.ActionHappened(_enemyData.GoldForKill);
            OriginSpawner.UnRegisterEnemy(this);
        }
    }
}