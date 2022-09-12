namespace InGameScene.TD.Enemies
{
    public class ZombieWalker : Enemy
    {
        protected override void Die()
        {
            base.Die();
            OriginFactory.Reclaim(this);
        }
    }
}