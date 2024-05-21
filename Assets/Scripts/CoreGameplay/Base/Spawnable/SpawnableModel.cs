using System;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public class SpawnableModel
    {
        public SpawnableData Data { get; }
        public event Action<SpawnableModel> Spawned;
        public event Action<SpawnableModel> AddedToPool;
        
        public SpawnableModel(SpawnableData data)
        {
            Data = data;
        }
        
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