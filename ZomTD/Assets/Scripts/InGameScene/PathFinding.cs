using System.Collections;
using System.Collections.Generic;
using InGameScene.Tiles;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private TilesBoard _tilesBoard;
    
    void Awake()
    {
        _tilesBoard = GetComponent<TilesBoard>();
    }

    public bool PathFind(Tile updatedTile)
    {
        updatedTile._TileType = Tile.TileType.Wall;
        Dictionary<Tile, Tile> nextTileToGoal = new Dictionary<Tile, Tile>();
        Queue<Tile> frontier = new Queue<Tile>();
        List<Tile> visited = new List<Tile>();

        frontier.Enqueue(_tilesBoard.EndTile());

        while(frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();

            foreach(Tile neighbor in _tilesBoard.Neighbors(curTile))
            {
                if (visited.Contains(neighbor) == false && frontier.Contains(neighbor) == false)
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        frontier.Enqueue(neighbor);
                        nextTileToGoal[neighbor] = curTile;
                    }
                }
            }
            visited.Add(curTile);
        }
        if (visited.Contains(_tilesBoard.StartTile()) == false)
        {
            updatedTile._TileType = Tile.TileType.Open;
            return false;
        }
        else
        {
            updatedTile._TileType = Tile.TileType.Open;
            return true;
        }
    }
}
