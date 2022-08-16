using System;
using System.Diagnostics;
using InGameScene.TD.Boards;
using InGameScene.TD.TDGamePlay;
using UnityEngine;
using InGameScene.TD.Boards.Tiles;
using UnityEngine.AI;
using InGameScene.Weapons;
using Debug = UnityEngine.Debug;

public enum PlannerAction
{
    Targeting,
    Box,
    Tower,
    Remove,
    Upgrade
}

 public class TowerPlanner : MonoBehaviour
 {
     [SerializeField] 
     private BlockBuilder _builder;
     
     private AIM _manager;

     private PathFinding _currentPathFinder;

     private Tile _selectedTile;

     private void Awake()
     {
         PlannerActionDispatcher.Instance.AddListener(action => PlannerActionCheck(action));
     }

     private void OnDestroy()
     {
         PlannerActionDispatcher.Instance.RemoveListener(action => PlannerActionCheck(action));
     }

     private void Start()
     {
         _manager = GetComponentInParent<AIM>();
        
     }
        
     private void PlannerActionCheck(PlannerAction actionType)
     {
         switch (actionType)
         {
             case PlannerAction.Targeting:
                 Targeting();
                 break;
             case PlannerAction.Box:
                 PutBox();
                 break;
             case PlannerAction.Tower:
                 PutTower();
                 break;
             case PlannerAction.Remove:
                 Sell();
                 break;
             case PlannerAction.Upgrade:
                 PreviewContentUpdateToPermanent();
                 break;
             default:
                 throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
         }
     }

     private void Targeting()
     {
         Tile targetTile = GetTile();
         if (_selectedTile != targetTile )
         {
             _selectedTile = targetTile;
             SelectTile(_selectedTile);
         }
     }

     public void PutBox()
     {
         if (_selectedTile != null && _selectedTile.CurrentTileType == Tile.TileType.Open )
         {
             _currentPathFinder = _selectedTile.GetComponentInParent<PathFinding>();
             if (_currentPathFinder.PathFind(_selectedTile))
             {
                 _builder.PutBox();
             }
         }
     }

     private void PutTower()
     {
         if (_selectedTile != null && _selectedTile.Content.Type == GameTileContentType.Box)
         {
             _builder.PutMachineGun();
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
             return null;
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


     private void SelectTile(Tile targetTile)
     {
         if (targetTile != null)
         {
             SelectedTileDispatcher.Instance.ActionHappened(_selectedTile);
         }
         else
         {
             SelectedTileDispatcher.Instance.ActionHappened(null);
         }
     }

     private void Sell()
     {
         if (_selectedTile != null && _selectedTile.CurrentTileType == Tile.TileType.Wall)
         {
             _builder.Sell();
         }
     }



     private void PreviewContentUpdateToPermanent()
     {
         if (_selectedTile != null)
         {
             _builder.ToPermanentContent();
        }
    }
     
 }

