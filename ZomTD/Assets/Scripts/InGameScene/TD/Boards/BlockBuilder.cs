using InGameScene.TD.Boards.Tiles;
using InGameScene.TD.TDGamePlay;
using UnityEngine;

namespace InGameScene.TD.Boards
{
    public class BlockBuilder : MonoBehaviour
    {
        private Tile _currentTile;
        
        [SerializeField] 
        private GameTileContentFactory _contentFactory;
        [SerializeField]
        private GameTileContentFactory _previewContentFactory;
        
        private void Awake()
        {
            SelectedTileDispatcher.Instance.AddListener(SelectTile);
        }
        private void OnDestroy()
        {
            SelectedTileDispatcher.Instance.RemoveListener(SelectTile);
        }

        private void SelectTile(Tile selectedTile)
        {
            _currentTile = selectedTile;
            if (_currentTile != null && _currentTile.CurrentTileType != Tile.TileType.Locked)
            {
                _currentTile.PreviewContent = _previewContentFactory.Get(_currentTile.Content.Type);
                _currentTile.ShowPreviewContent();
            }
                
        }
        
        
        public void ToPermanentContent()
        {
            if (_currentTile.Content.Type != _currentTile.PreviewContent.Type)
            {
                _currentTile.Content = _contentFactory.Get(_currentTile.PreviewContent.Type);
                if (_currentTile.PreviewContent.Type == GameTileContentType.Box)
                {
                    _currentTile.CurrentTileType = Tile.TileType.Wall;
                }
            }
        }

        public void Sell()
        {
            _currentTile.CurrentTileType = Tile.TileType.Open;
            _currentTile.Content = _contentFactory.Get(GameTileContentType.Empty);
        }

        public void PutBox()
        {
            _currentTile.PreviewContent = _previewContentFactory.Get(GameTileContentType.Box);
            
        }

        public void PutMachineGun()
        {
            _currentTile.PreviewContent = _previewContentFactory.Get(GameTileContentType.MachineGun);
        }

        public void Upgrade()
        {
            
        }
        
        
    }
}