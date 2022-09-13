using System;
using InGameScene.TD.Enemies;
using InGameScene.TD.TDGamePlay;
using UnityEngine;

namespace InGameScene.GamePlay
{
    public class EndPointHealthManager : MonoBehaviour
    {
        [SerializeField]
        private float _health;

        public float Health => _health;
        
        private void Awake()
        {
            EndPointHealthDispatcher.Instance.AddListener(damage => AddHealthValue(damage));
        }

        private void OnDestroy()
        {
            EndPointHealthDispatcher.Instance.RemoveListener(damage => AddHealthValue(damage));
        }

        private void AddHealthValue(float damage)
        {
            if (_health + damage > 0)
            {
                _health += damage;
            }
            else
            {
                Debug.Log("Game Over");
                GameFlowController.Instance.GameStateUpdater(GameState.GameLost);
            }
            
        }
        
    }
}