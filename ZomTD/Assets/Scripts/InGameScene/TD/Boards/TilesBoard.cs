using System.Collections;
using System.Collections.Generic;
using InGameScene.TD.Boards;
using InGameScene.TD.Boards.Tiles;
using UnityEngine;

public class TilesBoard : MonoBehaviour
{
    [SerializeField] 
    private Transform _tilesBoard;

    [SerializeField] 
    private Tile _gameTilePrefab;

    [SerializeField] 
    private float _tileSize = 1.75f;

    [SerializeField] 
    private GameTileContentFactory _contentFactory;
    
    private Tile[,] _grid;
    
    private Vector2Int _size;

    private Dictionary<Tile, Tile[]> neighborDictionary = new Dictionary<Tile, Tile[]>();

    private Tile _startTile;
    private Tile _endTile;

    public Tile StartTile() => _startTile;
    public Tile EndTile() => _endTile;
    
    public Tile[] Neighbors(Tile tile)
    {
        return neighborDictionary[tile];
    }
    
    public void Initialize(Vector2Int size)
    {
        _size = size;

        _grid = new Tile[size.x, size.y];
        
        _tilesBoard.localScale = new Vector3(size.x * _tileSize ,size.y * _tileSize ,1f );

        Vector2 offset = new Vector2((size.x - 1f) * 0.5f * _tileSize, (size.y - 1f) * 0.5f * _tileSize);

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                _grid[x, y] = Instantiate(_gameTilePrefab);
                _grid[x, y].transform.SetParent(transform, false);
                _grid[x, y].transform.localScale = new Vector3(_tileSize * 0.9f, _tileSize * 0.9f, 1f);
                _grid[x, y].transform.localPosition = new Vector3(
                    x * _tileSize - offset.x, y * _tileSize - offset.y,0f);
                _grid[x, y].Init(x, y);
                if (y == 0)
                {
                    _grid[x, y].CurrentTileType = Tile.TileType.Locked;
                    if (x == size.x / 2)
                    {
                        _startTile = _grid[x, y];
                        //_grid[x, y].CurrentTileType = Tile.TileType.StartPoint;
                    }
                } 
                else if (y == size.y-1)
                {
                    _grid[x, y].CurrentTileType = Tile.TileType.Locked;
                    if (x == size.x / 2)
                    {
                        _endTile = _grid[x, y];
                    }
                }
                else
                {
                    _grid[x, y].Content = _contentFactory.Get(GameTileContentType.Empty);
                }
            }
        }
        
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                List<Tile> neighbors = new List<Tile>();
                if (y < size.y-1)
                    neighbors.Add(_grid[x, y + 1]);
                if (x < size.x-1)
                    neighbors.Add(_grid[x + 1, y]);
                if (y > 0)
                    neighbors.Add(_grid[x, y - 1]);
                if (x > 0)
                    neighbors.Add(_grid[x - 1, y]);

                neighborDictionary.Add(_grid[x, y], neighbors.ToArray());
            }
        }
    }
    
    public void ResetTiles()
    {
        foreach(Tile t in _grid)
        {
            //t._Color = Color.white;
            //t._Text = "";
        }
    }
}
