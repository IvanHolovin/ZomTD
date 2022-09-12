namespace InGameScene.TD.Enemies
{
    public class HugeZombie : Enemy
    {
        protected override void Die()
        {
            base.Die();
            OriginFactory.Reclaim(this);
        }
    }
}