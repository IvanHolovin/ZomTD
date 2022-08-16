using System;
using UnityEngine;
using InGameScene.TD.Boards.Tiles;

namespace InGameScene.TD.Boards
{
    [CreateAssetMenu]
    public class GameTileContentFactory : ScriptableObject
    {
        [SerializeField] 
        private GameTileContent _emptyPrefab;
        [SerializeField] 
        private GameTileContent _boxPrefab;
        [SerializeField] 
        private GameTileContent _machineGunTurret;
        
        
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
            }
            return null;
        }
        
        private GameTileContent Get(GameTileContent prefab)
        {
            GameTileContent instance = Instantiate(prefab);
            instance.OriginFactory = this;
            return instance;
        }
    }
}