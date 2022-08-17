using System;
using System.Collections;
using System.Collections.Generic;
using InGameScene.TD.Boards;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class GameTileContent : MonoBehaviour
    {
        [SerializeField] 
        private GameTileContentType _gameTileContentType;

        private GameTileContentType _currentTileContentType;
        
        public GameTileContentType Type => _gameTileContentType;
        public GameTileContentFactory OriginFactory { get; set; }

        public BlockContent blockContent;
        
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
    MachineGun
}