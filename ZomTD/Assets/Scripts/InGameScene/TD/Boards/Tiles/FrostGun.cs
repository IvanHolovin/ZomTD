using InGameScene.TD.Enemies;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class FrostGun : Tower
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeSlow(_towerType.SlowRate);
                _audioSource.PlayOneShot(_shotAudioClip);
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().RemoveSlow();
            }
        }
    }
}