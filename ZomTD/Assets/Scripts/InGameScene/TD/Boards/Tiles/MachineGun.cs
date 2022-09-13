using System;
using InGameScene.TD.Enemies;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace InGameScene.TD.Boards.Tiles
{
    public class MachineGun : Tower
    {
        [SerializeField]
        private Transform _rotateHead;
        
        private Enemy _currentTarget;
        
        private float attackRateTime = 1f;
        
        private float timer;
        
        
        private void Update()
        {
           Target();
           timer += Time.deltaTime;
        }

        private void Start()
        {
            
        }

        private void Target()
        {
            if(enemyList.Count > 0)
            {
                if (enemyList[0] == null)
                {
                    enemyList.Remove(enemyList[0]);
                    return;
                }
                _currentTarget = enemyList[0];

                Vector3 dir = _currentTarget.targetPoint.position - _rotateHead.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                _rotateHead.rotation = lookRotation;
                if (timer >= attackRateTime)
                {
                    timer = 0;
                    Shot();
                }
                
            }
            else
            {
                _currentTarget = null;
            }
        }

        private void Shot()
        {
            _currentTarget.TakeDamage((float)_towerType.damage); 
        }
    }
}