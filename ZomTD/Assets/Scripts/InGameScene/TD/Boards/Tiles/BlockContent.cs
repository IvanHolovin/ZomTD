using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    [CreateAssetMenu]
    public class BlockContent : ScriptableObject
    {
        public uint cost;
        public uint sellCost;
        public uint damage;
        public uint attackRange;
    }
}