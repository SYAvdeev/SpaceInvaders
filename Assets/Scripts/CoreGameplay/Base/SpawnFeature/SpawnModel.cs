using System;
using System.Collections.Generic;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using SpaceInvaders.Utility;

namespace SpaceInvaders.CoreGameplay.Base.SpawnFeature
{
    public class SpawnModel
    {
        internal Pool<string, SpawnableModel> SpawnablesPool { get; } = new();
        internal List<SpawnableModel> CurrentSpawnables { get; } = new();

        internal event Action<SpawnableModel> SpawnableAdded;
        internal event Action<SpawnableModel> SpawnableRemoved;

        internal void FireSpawnableAddedEvent(SpawnableModel spawnableModel)
        {
            SpawnableAdded?.Invoke(spawnableModel);
        }
        
        internal void FireSpawnableRemovedEvent(SpawnableModel spawnableModel)
        {
            SpawnableRemoved?.Invoke(spawnableModel);
        }
    }
}