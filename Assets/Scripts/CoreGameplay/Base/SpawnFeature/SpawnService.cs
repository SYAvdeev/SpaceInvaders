using System;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Base.SpawnFeature
{
    public class SpawnService<TData, TModel>
        where TData : SpawnableData
        where TModel : SpawnableModel
    {
        private readonly SpawnableModelFactory<TData, TModel> _spawnableModelFactory;
        private readonly SpawnModel _spawnModel;
        private readonly SpawnableCollectionConfig<TData> _collectionConfig;

        public SpawnService(SpawnableModelFactory<TData, TModel> spawnableModelFactory, SpawnModel spawnModel, SpawnableCollectionConfig<TData> collectionConfig)
        {
            _spawnableModelFactory = spawnableModelFactory;
            _spawnModel = spawnModel;
            _collectionConfig = collectionConfig;
        }

        public TModel Spawn(string spawnableID)
        {
            if(!_spawnModel.SpawnablesPool.TryGet(spawnableID, out SpawnableModel spawnableModel))
            {
                if (_collectionConfig.GetByID(spawnableID, out SpawnableConfig<TData> config))
                {
                    spawnableModel = _spawnableModelFactory.Create(config.CopyData());
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            
            spawnableModel.AddedToPool += SpawnableModelOnAddedToPool;
            _spawnModel.CurrentSpawnables.Add(spawnableModel);
            _spawnModel.FireSpawnableAddedEvent(spawnableModel);

            return (TModel)spawnableModel;
        }

        private void SpawnableModelOnAddedToPool(SpawnableModel spawnableModel)
        {
            _spawnModel.CurrentSpawnables.Remove(spawnableModel);
            _spawnModel.SpawnablesPool.Add(spawnableModel.Data.ID, spawnableModel);
            _spawnModel.FireSpawnableRemovedEvent(spawnableModel);
            spawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
        }
    }
}