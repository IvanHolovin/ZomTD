using UnityEngine;

namespace InGameScene.TD.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "EnemyData")]
    public class EnemyScriptableObj : ScriptableObject
    {
        [SerializeField] 
        private float _health;
        
        [SerializeField]
        private EnemyType _enemyType;

        [SerializeField] 
        private float _attackDamage;

        [SerializeField] 
        private float _damageToEndPoint;

        [SerializeField] 
        private int _goldForKill;

        [SerializeField] 
        private bool _canSlowDown;

        public float Health => _health;
        
        public EnemyType EnemyType => _enemyType;
        
        public float AttackDamage => _attackDamage;
        
        public float DamageToEndPoint => _damageToEndPoint;
        
        public int GoldForKill => _goldForKill;
        
        public bool CanSlowDown => _canSlowDown;

    }
}