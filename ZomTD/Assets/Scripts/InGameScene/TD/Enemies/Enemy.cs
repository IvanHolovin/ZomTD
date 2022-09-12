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
        private float _health;
        
        [SerializeField]
        protected float _attackDamage;

        [SerializeField] 
        private int _goldForKill;
        
        public Transform targetPoint;
        
        public EnemyFactory OriginFactory { get; set; }
        
        [SerializeField] 
        private EnemyType _enemyType;
        
        public SpawnManager OriginSpawner { get; set; }

        private NavMeshAgent _navMeshAgent;
        private float _moveSpeed;
        private bool _slowed = default;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _moveSpeed = _navMeshAgent.speed;
        }

        public EnemyType EnemyType
        {
            get => _enemyType;
        }

        public void TakeDamage(float damage)
        {
            if (_health > 0)
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
            if (!_slowed)
            {
                _navMeshAgent.speed -= _navMeshAgent.speed * slowRate/100;
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

        public void RemoveSlow()
        {
            _navMeshAgent.speed = _moveSpeed;
            _slowed = false;
        }
        
        protected virtual void Die()
        {
            MoneyIncomeDispatcher.Instance.ActionHappened(_goldForKill);
            OriginSpawner.UnRegisterEnemy(this);
        }
    }
}