using InGameScene.TD.TDGamePlay;
using UnityEngine;

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
                Debug.Log("die");
                Die();
            }
        }

        protected virtual void Die()
        {
            MoneyIncomeDispatcher.Instance.ActionHappened(_goldForKill);
            OriginSpawner.UnRegisterEnemy(this);
        }
    }
}