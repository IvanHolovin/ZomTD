using InGameScene.TD.Enemies;
using InGameScene.Weapons;
using UnityEngine;

namespace InGameScene.GamePlay
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _shotSplash;
        [SerializeField] private WeaponData _weaponData;

        private AudioSource _audioSource;
        private AIM _aimManager;
        private float _nextFire = 0;
        
        private void Awake()
        {
            _aimManager = GetComponentInParent<AIM>();
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void Shot()
        {
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + 1f / _weaponData.FireRate;
                _shotSplash.Play();
                _audioSource.PlayOneShot(_weaponData.ShotAudioClip);
                if (_aimManager.Target(int.MaxValue) != null &&
                    _aimManager.Target(int.MaxValue).transform.GetComponentInParent<Enemy>() != null)
                {
                    Enemy target = _aimManager.Target((int)_weaponData.Range).GetComponent<Enemy>();
                    target.TakeDamage(_weaponData.Damage);
                }
            }
            
        }

        public void Fire()
        {
            Shot();
        }
    }
}