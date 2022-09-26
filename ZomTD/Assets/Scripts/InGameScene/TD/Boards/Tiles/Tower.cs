using System.Collections.Generic;
using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] protected BlockContent _towerType;
        [SerializeField] private SphereCollider _range;
        [SerializeField] protected AudioClip _shotAudioClip;

        protected AudioSource _audioSource;
        protected List<Enemy> _enemyList;

        private void Awake()
        {
            _enemyList = new List<Enemy>();
            _range.radius = _towerType.AttackRange;
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemyList.Add(other.GetComponent<Enemy>());
            }
        }
        
        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemyList.Remove(other.GetComponent<Enemy>());
            }
        }
        
    }
}