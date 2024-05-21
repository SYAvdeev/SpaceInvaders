using System;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public class SpawnablePresenter : IDisposable
    {
        protected readonly SpawnableModel _spawnableModel;
        protected readonly SpawnableView _spawnableView;

        public SpawnablePresenter(SpawnableModel spawnableModel, SpawnableView spawnableView)
        {
            _spawnableModel = spawnableModel;
            _spawnableView = spawnableView;
            spawnableModel.Spawned += SpawnableModelOnSpawned;
        }

        protected virtual void SpawnableModelOnSpawned(SpawnableModel spawnableModel)
        {
            spawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
            _spawnableView.OnAddedToPool();
        }

        private void SpawnableModelOnAddedToPool(SpawnableModel spawnableModel)
        {
            _spawnableModel.AddedToPool += SpawnableModelOnAddedToPool;
        }
        
        public void RequestAddToPool()
        {
            _spawnableModel.FireAddedToPoolEvent();
        }
        
        public virtual void Dispose()
        {
            _spawnableModel.Spawned -= SpawnableModelOnSpawned;
            _spawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
        }
    }
}