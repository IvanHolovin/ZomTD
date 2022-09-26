using System.Collections.Generic;
using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public enum DamageType
    {
        None,
        Single,
        Splash
    }
    
    [CreateAssetMenu(fileName = "New block content", menuName = "ContentData")]
    public class BlockContent : ScriptableObject
    {
        [SerializeField] private uint _cost;
        [SerializeField] private uint _sellCost;
        [SerializeField] private uint _damage;
        [SerializeField] private uint _attackRange;
        [SerializeField] private uint _slowRate;
        [SerializeField] private List<GameTileContentType> _availableToBuild;
        [SerializeField] private bool _isUpgradable;
        [SerializeField] private GameTileContentType _nextUpgrade;
        [SerializeField] private DamageType _damageType;

        public uint Cost => _cost;
        public uint SellCost => _sellCost;
        public uint Damage => _damage;
        public uint AttackRange => _attackRange;
        public uint SlowRate => _slowRate;
        public List<GameTileContentType> AvailableToBuild => _availableToBuild;
        public bool IsUpgradable => _isUpgradable;
        public GameTileContentType NextUpgrade => _nextUpgrade;
        public DamageType DamageType => _damageType;
        
    }
}