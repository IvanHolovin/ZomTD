using System;
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
                other.GetComponent<Enemy>().TakeSlow(_towerType.slowRate);
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