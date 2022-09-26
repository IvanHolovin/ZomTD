using UnityEngine;

namespace InGameScene.GamePlay
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private int _range;
        [SerializeField] private float _fireRate;
        [SerializeField] private AudioClip _shotAudioClip;
        
        public float Damage => _damage;
        public float Range => _range;
        public float FireRate => _fireRate;
        public AudioClip ShotAudioClip => _shotAudioClip;
    }
}