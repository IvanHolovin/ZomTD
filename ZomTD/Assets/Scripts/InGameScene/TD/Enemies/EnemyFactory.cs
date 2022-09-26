using UnityEngine;

namespace InGameScene.TD.Enemies
{
    [CreateAssetMenu]
    public class EnemyFactory : InstanceFactory
    {
        [SerializeField] private Enemy _zombieWalker;
        [SerializeField] private Enemy _hugeZombie;
        
        public void Reclaim(Enemy content)
        {
            Destroy(content.gameObject);
        }
        
        public Enemy Get(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.ZombieWalker:
                    return Get(_zombieWalker);
                case EnemyType.HugeZombie:
                    return Get(_hugeZombie);
            }
            return null;
        }
        
        private Enemy Get(Enemy prefab)
        {
            Enemy instance = GetInstance(prefab);
            instance.OriginFactory = this;
            return instance;
        }
        
    }
}