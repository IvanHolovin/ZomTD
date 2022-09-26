using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class GameTileContent : MonoBehaviour
    {
        [SerializeField] private GameTileContentType _gameTileContentType;
        
        private GameTileContentType _currentTileContentType;
        
        public BlockContent blockContent;
        public GameTileContentType Type => _gameTileContentType;
        public GameTileContentFactory OriginFactory { get; set; }

        public void Recycle()
        {
            OriginFactory.Reclaim(this);
        }
    }
}

public enum GameTileContentType
{
    Empty,
    Box,
    MachineGun,
    MachineGunLvl2,
    FrostGun
}