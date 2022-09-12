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
        [SerializeField]
        private MoneyManger _moneyManager;
        
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
                if (_moneyManager.SpendMoney((int)_currentTile.PreviewContent.blockContent.cost))
                {
                    _currentTile.Content = _contentFactory.Get(_currentTile.PreviewContent.Type);
                    if (_currentTile.PreviewContent.Type == GameTileContentType.Box)
                    {
                        _currentTile.CurrentTileType = Tile.TileType.Wall;
                        _currentTile = null;
                    }
                }
            }
        }

        public void Sell()
        {
            _moneyManager.AddMoney((int)_currentTile.Content.blockContent.sellCost);
            _currentTile.CurrentTileType = Tile.TileType.Open;
            _currentTile.Content = _contentFactory.Get(GameTileContentType.Empty);
        }

        public void PutBox()
        {
            if(_currentTile != null)
                _currentTile.PreviewContent = _previewContentFactory.Get(GameTileContentType.Box);
            
        }

        public void PutTower(GameTileContentType type)
        {
            if(_currentTile != null)
                _currentTile.PreviewContent = _previewContentFactory.Get(type);
        }

        public void Upgrade()
        {
            
        }
        
        
    }
}