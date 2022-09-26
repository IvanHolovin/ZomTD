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
        [SerializeField] private EnemyScriptableObj _enemyData;
        [SerializeField] private ZombieAggroTrigger _aggroTrigger;
        
        private float _moveSpeed;
        private bool _isSlowed;
        private float _health;
        private bool _isDestinationReseted = true;
        private NavMeshAgent _navMeshAgent;
        private GameObject _destinationPoint;
        
        public Transform targetPoint;
        
        public EnemyFactory OriginFactory { get; set; }
        
        public SpawnManager OriginSpawner { get; set; }
        
        public EnemyType EnemyType => _enemyData.EnemyType;

        private void Awake()
        {
            _health = _enemyData.Health;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _moveSpeed = _navMeshAgent.speed;
        }

        private void Update()
        {
            if (_aggroTrigger.IsFollowing)
            {
                _navMeshAgent.destination = _aggroTrigger.FollowPlayer().transform.position;
                _isDestinationReseted = false;
            }
            else if (!_aggroTrigger.IsFollowing && !_isDestinationReseted)
            {
                _navMeshAgent.destination = _destinationPoint.transform.position;
                _isDestinationReseted = true;
            }
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
                if (!_isSlowed)
                {
                    _navMeshAgent.speed -= _navMeshAgent.speed * slowRate / 100;
                    _isSlowed = true;
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
            _isSlowed = false;
        }

        public float EndPointReachDamage()
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