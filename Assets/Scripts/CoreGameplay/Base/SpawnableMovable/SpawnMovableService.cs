using SpaceInvaders.CoreGameplay.Base.SpawnFeature;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnMovableService : SpawnService<SpawnableMovableData, SpawnableMovableModel>
    {
        public SpawnMovableService(SpawnableMovableModelFactory spawnableModelFactory, SpawnModel spawnModel, SpawnableMovableCollectionConfig collectionConfig) : base(spawnableModelFactory, spawnModel, collectionConfig)
        {
        }
        
        public void Spawn(string spawnableID, Vector2 position, Vector2 direction)
        {
            SpawnableMovableModel spawnableMovableModel = Spawn(spawnableID);
            spawnableMovableModel.Data.MovableData.Position = position;
            spawnableMovableModel.Data.MovableData.DirectionNormalized = direction;
        }
    }
}