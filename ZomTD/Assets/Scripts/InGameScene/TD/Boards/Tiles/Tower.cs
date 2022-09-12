using System;
using System.Collections.Generic;
using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] 
        protected BlockContent _towerType;

        [SerializeField] 
        private SphereCollider _range;

        protected List<Enemy> enemyList;

        private void Awake()
        {
            enemyList = new List<Enemy>();
            _range.radius = _towerType.attackRange;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemyList.Add(other.GetComponent<Enemy>());
                Debug.Log("enemy added");
            }
        }
        
        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemyList.Remove(other.GetComponent<Enemy>());
            }
        }
        
    }
}