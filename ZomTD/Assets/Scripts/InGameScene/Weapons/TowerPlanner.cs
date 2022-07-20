using System;
using UnityEngine;
using UnityEngine.AI;

namespace InGameScene.Weapons
{
    public class TowerPlanner : MonoBehaviour, IWeapon
    {
        [SerializeField] 
        private NavMeshSurface _surface;
        
        private WeaponManager _manager;
        
        private PathFinding currentPathFinder;

        private Tile _previuosTile;

        private void Start()
        {
            _manager = GetComponentInParent<WeaponManager>();
        }

        public void Shot()
        {
            Tile targetTile = GetTile();
            if(targetTile != null)
            {
                currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                if (currentPathFinder.PathFind(targetTile))
                {
                    targetTile._TileType = Tile.TileType.Wall;
                    
                    Debug.Log("open");
                }
                else
                {
                    targetTile._TileType = Tile.TileType.Open;
                    
                    Debug.Log("closed");
                }
            }
        
        }
        

        private Tile GetTile()
        {
            //Ray ray = playerCam.transform.position,;
            RaycastHit rayHit;
            bool wasHit = Physics.Raycast(_manager.PlayerCam().transform.position,_manager.PlayerCam().transform.forward, out rayHit, int.MaxValue, LayerMask.GetMask("Tiles"));
            if (wasHit)
                return rayHit.transform.GetComponent<Tile>();
            else
                return null;
        }
        
        private Wall GetWall()
        {
            //Ray ray = playerCam.transform.position,;
            RaycastHit rayHit;
            bool wasHit = Physics.Raycast(_manager.PlayerCam().transform.position,_manager.PlayerCam().transform.forward, out rayHit, int.MaxValue, LayerMask.GetMask("Tiles"));
            if (wasHit)
                return rayHit.transform.GetComponent<Wall>();
            else
                return null;
        }
        

        public void Targeting()
        {
            Tile targetTile = GetTile();
            if (targetTile != null && targetTile._TileType == Tile.TileType.Open)
            {
                currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                if (targetTile != _previuosTile) 
                {
                    targetTile.PlayAnimation(true,currentPathFinder.PathFind(targetTile));
                    if(_previuosTile != null) 
                        _previuosTile.PlayAnimation(false,false);
                }
                
                _previuosTile = targetTile;
            }
            else
            {   if(_previuosTile != null)
                _previuosTile.PlayAnimation(false,false);
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