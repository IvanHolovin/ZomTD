using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class MachineGunLvl2 : MachineGun
    {
        [SerializeField] private ParticleSystem _shot2;
        [SerializeField] private ParticleSystem _shot3;
        
        protected override void Shot()
        {
            base.Shot();
            _shot2.Play();
            _shot3.Play();
        }
    }
}