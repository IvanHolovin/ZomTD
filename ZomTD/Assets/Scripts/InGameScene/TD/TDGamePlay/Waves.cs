using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.TDGamePlay
{   
    [CreateAssetMenu(fileName = "New Enemy Wave", menuName = "WaveData")]
    public class Waves : ScriptableObject
    {
        [SerializeField] private EnemyType[] _simpleEnemies;
        [SerializeField] private int _simpleEnemiesCount;
        [SerializeField] private EnemyType _bossEnemy;
        [SerializeField] private int _bossCount;
        
        public EnemyType[] SimpleEnemies => _simpleEnemies;
        public int SimpleEnemiesCount => _simpleEnemiesCount;
        public EnemyType BossEnemy => _bossEnemy;
        public int BossCount => _bossCount;
    }
    
}