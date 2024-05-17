namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public class SpawnableService
    {
        public void AddToPool(SpawnableModel spawnableModel)
        {
            spawnableModel.FireAddedToPoolEvent();
        }
    }
}