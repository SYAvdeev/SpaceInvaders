using System;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public class SpawnableModel
    {
        public event Action<SpawnableModel> Spawned;
        public event Action<SpawnableModel> AddedToPool;

        public void FireAddedToPoolEvent()
        {
            AddedToPool?.Invoke(this);
        }
        
        public void FireSpawnedEvent()
        {
            Spawned?.Invoke(this);
        }
    }
}