using System;
using UnityEngine;
using UnityEngine.AI;
using InGameScene.Tiles;

enum PlannerAction
{
    Targeting,
    Select,
    Remove,
    Update
}
namespace InGameScene.Weapons
{
    public class TowerPlanner : MonoBehaviour, IWeapon
    {

        private AIM _manager;

        private PathFinding _currentPathFinder;

        private Tile _previuosTile;

        private void Start()
        {
            _manager = GetComponentInParent<AIM>();
        }

        public void Shot()
        {

            Tile targetTile = GetTile();
            if (targetTile != null && targetTile._TileType == Tile.TileType.Open)
            {
                _currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                if (_currentPathFinder.PathFind(targetTile))
                {
                    targetTile._TileType = Tile.TileType.Wall;
                }
            }

        }


        private Tile GetTile()
        {

            if (_manager.Target() != null && _manager.Target().transform.GetComponentInParent<Tile>() != null)
            {
                Tile tile = _manager.Target().transform.GetComponentInParent<Tile>();
                return tile;
            }
            else
            {
                return null;
            }
        }



        private Wall GetWall()
        {
            if (_manager.Target().GetComponentInParent<Wall>() != null)
            {
                Wall wall = _manager.Target().GetComponentInParent<Wall>();
                return wall;
            }
            else
                return null;
        }


        public void Targeting()
        {
            Tile targetTile = GetTile();
            if (targetTile != null && targetTile._TileType == Tile.TileType.Open)
            {
                _currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                if (targetTile != _previuosTile)
                {
                    targetTile.PlayAnimation(true, _currentPathFinder.PathFind(targetTile));
                    if (_previuosTile != null)
                        _previuosTile.PlayAnimation(false, false);
                }

                _previuosTile = targetTile;
            }
            else
            {
                if (_previuosTile != null)
                    _previuosTile.PlayAnimation(false, false);
                _previuosTile = null;
            }
        }

        public void Reload()
        {
            Wall targetWall = GetWall();
            if (targetWall != null && targetWall.GetComponentInParent<Tile>()._TileType == Tile.TileType.Wall)
            {
                targetWall.GetComponentInParent<Tile>()._TileType = Tile.TileType.Open;
            }
        }
    }

}