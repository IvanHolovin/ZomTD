using System;
using InGameScene.TD.Boards;
using InGameScene.TD.TDGamePlay;
using UnityEngine;
using InGameScene.TD.Boards.Tiles;
using InGameScene.Weapons;

public enum PlannerAction
{
    Targeting,
    Box,
    Tower,
    FrostGun,
    Remove,
    Upgrade
}

 public class TowerPlanner : MonoBehaviour
 {
     [SerializeField] private BlockBuilder _builder;
     
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
                 PutTower(GameTileContentType.MachineGun);
                 break;
             case PlannerAction.FrostGun:
                 PutTower(GameTileContentType.FrostGun);
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
         if (_selectedTile != null && _selectedTile.Content.blockContent.AvailableToBuild.Contains(GameTileContentType.Box) )
         {
             _currentPathFinder = _selectedTile.GetComponentInParent<PathFinding>();
             if (_currentPathFinder.PathFind(_selectedTile))
             {
                 _builder.PutBox();
             }
         }
     }

     private void PutTower(GameTileContentType type)
     {
         if (_selectedTile != null && _selectedTile.Content.blockContent.AvailableToBuild.Contains(type))
         {
             _builder.PutTower(type);
         }
     }
     
     private Tile GetTile()
     {
         if (_manager.Target(int.MaxValue) != null && _manager.Target(int.MaxValue).transform.GetComponentInParent<Tile>() != null)
         {
             Tile tile = _manager.Target(int.MaxValue).transform.GetComponentInParent<Tile>();
             return tile;
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
         if (_selectedTile != null && _selectedTile.CurrentTileType == Tile.TileType.Wall )
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

