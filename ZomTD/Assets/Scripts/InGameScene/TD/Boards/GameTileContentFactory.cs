using System;
using UnityEngine;
using InGameScene.TD.Boards.Tiles;

namespace InGameScene.TD.Boards
{
    [CreateAssetMenu]
    public class GameTileContentFactory : InstanceFactory
    {
        [SerializeField] 
        private GameTileContent _emptyPrefab;
        [SerializeField] 
        private GameTileContent _boxPrefab;
        [SerializeField] 
        private GameTileContent _machineGunTurret;
        [SerializeField] 
        private GameTileContent _machineGunTurretLvl2;
        [SerializeField] 
        private GameTileContent _frostGun;
        
        
        public void Reclaim(GameTileContent content)
        {
            Destroy(content.gameObject);
        }

        public GameTileContent Get(GameTileContentType type)
        {
            switch (type)
            {
                case GameTileContentType.Empty:
                    return Get(_emptyPrefab);
                case GameTileContentType.Box:
                    return Get(_boxPrefab);
                case GameTileContentType.MachineGun:
                    return Get(_machineGunTurret);
                case GameTileContentType.MachineGunLvl2:
                    return Get(_machineGunTurretLvl2);
                case GameTileContentType.FrostGun:
                    return Get(_frostGun);
            }
            return null;
        }
        
        private GameTileContent Get(GameTileContent prefab)
        {
            GameTileContent instance = GetInstance(prefab);
            instance.OriginFactory = this;
            return instance;
        }
    }
}