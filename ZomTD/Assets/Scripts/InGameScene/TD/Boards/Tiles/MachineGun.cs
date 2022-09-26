using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class MachineGun : Tower
    {
        [SerializeField] private Transform _rotateHead;
        [SerializeField] private ParticleSystem _shotParticle;
        
        private Enemy _currentTarget;
        private float _attackRateTime = 0.5f;
        private float _timer;
        
        private void Update()
        {
           Target();
           _timer += Time.deltaTime;
        }

        private void Target()
        {
            if(_enemyList.Count > 0)
            {
                if (_enemyList[0] == null)
                {
                    _enemyList.Remove(_enemyList[0]);
                    return;
                }
                _currentTarget = _enemyList[0];
                Vector3 dir = _currentTarget.targetPoint.position - _rotateHead.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                _rotateHead.rotation = lookRotation;
                if (_timer >= _attackRateTime)
                {
                    _timer = 0;
                    Shot();
                }
            }
            else
            {
                _currentTarget = null;
            }
        }

        protected virtual void Shot()
        {
            _currentTarget.TakeDamage((float)_towerType.Damage); 
            _shotParticle.Play();
            _audioSource.PlayOneShot(_shotAudioClip);
        }
    }
}