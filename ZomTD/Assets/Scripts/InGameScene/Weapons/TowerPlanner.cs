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

        private void Start()
        {
            _manager = GetComponentInParent<WeaponManager>();
        }

        public void Shot()
        {
            Tile targetTile = GetTile();
            if(targetTile != null){
                currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                targetTile._TileType = Tile.TileType.Wall;
                if (currentPathFinder.PathFind())
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
        

        public void Targeting()
        {
            Tile targetTile = GetTile();
            if (targetTile != null)
            {
                currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
                if (targetTile._TileType == Tile.TileType.Open)
                {
                    
                }
            }
        }
    }
}