using System;
using System.Collections;
using System.Collections.Generic;
using InGameScene.TD.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InGameScene.TD.TDGamePlay
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] 
        private EnemyFactory _enemyFactory = default;

        [SerializeField] 
        private Waves[] _waves;

        [SerializeField, Range(0.1f, 10f)] 
        private float _spawnSpeed = 1f;

        [SerializeField] 
        private Transform _spawnPoint;

        private List<Enemy> _enemyRegister = new List<Enemy>();
        
        private int _currentWave=0;
        

        private void Start()
        {
            StartCoroutine(SpawnEnemies(_waves[_currentWave]));
        }

        void Update()
        {
            
            
        }

        private void InstatiateEnemy(EnemyType enemyType)
        {
            Enemy enemy = _enemyFactory.Get(enemyType);
            //enemy.transform.parent = transform;
            enemy.OriginSpawner = this;
            enemy.transform.localPosition = _spawnPoint.transform.localPosition;
            
            _enemyRegister.Add(enemy);
        }

        private IEnumerator SpawnEnemies(Waves waveToSpawn)
        {
            for(int i=0; i < waveToSpawn.simpleEnemiesCount; i++)
            {
                yield return new WaitForSeconds(_spawnSpeed);
                InstatiateEnemy(_waves[_currentWave].simpleEnemies[Random.Range(0,waveToSpawn.simpleEnemies.Length)]);
            }
            
            for(int i=0; i < waveToSpawn.bossCount; i++)
            {
                yield return new WaitForSeconds(_spawnSpeed * 2);
                InstatiateEnemy(_waves[_currentWave].bossEnemy);
            }
            yield break;
        }

        public void UnRegisterEnemy(Enemy enemy)
        {
            _enemyRegister.Remove(enemy);
        }
        
    }
}
