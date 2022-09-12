using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public enum DamageType
    {
        None,
        Single,
        Splash
    }
    [CreateAssetMenu]
    public class BlockContent : ScriptableObject
    {
        public uint cost;
        public uint sellCost;
        public uint damage;
        public uint attackRange;
        public DamageType _DamageType;
    }
}