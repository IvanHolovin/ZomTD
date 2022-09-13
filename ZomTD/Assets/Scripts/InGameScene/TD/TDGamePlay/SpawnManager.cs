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
        
        private int _currentWave;
        
        private int _enemiesToSpawn;

        [SerializeField] 
        private GameObject _destinationPoint;
        

        private void Awake()
        {
            GameStateDispatcher.Instance.AddListener(state => StartSpawner(state));
        }

        private void OnDestroy()
        {
            GameStateDispatcher.Instance.RemoveListener(state => StartSpawner(state));
        }

        void Update()
        {
            
            if (_enemiesToSpawn == 0 && _enemyRegister.Count == 0 && GameFlowController.Instance.State == GameState.ShooterPhase)
            {
                GameFlowController.Instance.GameStateUpdater(GameState.WaveWon);
                _currentWave++;
            }
        }


        private void StartSpawner(GameState state)
        {
            if (state == GameState.ShooterPhase && _waves.Length > _currentWave)
            {
                _enemiesToSpawn = _waves[_currentWave].bossCount + _waves[_currentWave].simpleEnemiesCount;
                StartCoroutine(SpawnEnemies(_waves[_currentWave]));
            } 
            else if (state == GameState.ShooterPhase && _waves.Length == _currentWave)
            {
                Debug.Log("EndGame");
                _enemiesToSpawn = 100;
                GameFlowController.Instance.GameStateUpdater(GameState.PlanningPhase);
            }
        }

        private void InstatiateEnemy(EnemyType enemyType)
        {
            Enemy enemy = _enemyFactory.Get(enemyType);
            enemy.OriginSpawner = this;
            enemy.transform.localPosition = _spawnPoint.transform.localPosition;
            enemy.transform.SetParent(transform);
            enemy.SetDestination(_destinationPoint);
            _enemyRegister.Add(enemy);
        }

        private IEnumerator SpawnEnemies(Waves waveToSpawn)
        {
            for(int i=0; i < waveToSpawn.simpleEnemiesCount; i++)
            {
                yield return new WaitForSeconds(_spawnSpeed);
                InstatiateEnemy(_waves[_currentWave].simpleEnemies[Random.Range(0,waveToSpawn.simpleEnemies.Length)]);
                _enemiesToSpawn--;
            }
            
            for(int i=0; i < waveToSpawn.bossCount; i++)
            {
                yield return new WaitForSeconds(_spawnSpeed * 2);
                InstatiateEnemy(_waves[_currentWave].bossEnemy);
                _enemiesToSpawn--;
            }
            yield break;
        }

        public void UnRegisterEnemy(Enemy enemy)
        {
            _enemyRegister.Remove(enemy);
        }
        
    }
}
