using System.Collections.Generic;
using InGameScene.TD.Boards.Tiles;
using UnityEngine;

namespace InGameScene.TD.Boards
{
    public class TileSelector : MonoBehaviour
    {
        private List<Tile> _tilesBench;

        private void Awake()
        {
            SelectedTileDispatcher.Instance.AddListener(SelectTile);
        }
        private void OnDestroy()
        {
            SelectedTileDispatcher.Instance.RemoveListener(SelectTile);
        }

        public void RegisterTile(Tile tile)
        {
            if (_tilesBench == null)
            {
                _tilesBench = new List<Tile>();
            }
            _tilesBench.Add(tile);
        }
        
        public void UnRegisterTile(Tile tile)
        {
            _tilesBench.Remove(tile);
        }
        
        private void SelectTile(Tile selectedTile)
        {
            if (_tilesBench != null)
            {
                foreach (Tile tiles in _tilesBench)
                {
                    if (tiles == selectedTile)
                    {
                        if (selectedTile.CurrentTileType == Tile.TileType.Open || selectedTile.CurrentTileType == Tile.TileType.NotOpen)
                        {
                            PathFinding currentPathFinder = selectedTile.GetComponentInParent<PathFinding>();
                            if (currentPathFinder.PathFind(selectedTile))
                            {
                                selectedTile.CurrentTileType = Tile.TileType.Open;
                            }
                            else
                            {
                                selectedTile.CurrentTileType = Tile.TileType.NotOpen;
                            }
                        }
                        tiles.SelectThisTile();
                    }
                    else
                    {
                        tiles.DeselectThisTile();
                    }
                }
            }
        }
    }
}