using System;
using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletPresenter : IDisposable
    {
        private readonly BulletModel _bulletModel;
        private readonly BulletView _bulletView;
        private readonly MovableService _movableService;
        private readonly SpawnableService _spawnableService;

        public BulletPresenter(BulletModel bulletModel, BulletView bulletView, MovableService movableService, SpawnableService spawnableService)
        {
            _bulletModel = bulletModel;
            _bulletView = bulletView;
            _movableService = movableService;
            _spawnableService = spawnableService;
            _bulletModel.SpawnableModel.Spawned += SpawnableModelOnSpawned;
        }

        private void SpawnableModelOnAddedToPool(SpawnableModel spawnableModel)
        {
            _bulletModel.MovableModel.PositionChanged -= MovableModelOnPositionChanged;
            _bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
            _bulletView.OnAddedToPool();
        }

        private void SpawnableModelOnSpawned(SpawnableModel spawnableModel)
        {
            _bulletModel.MovableModel.PositionChanged += MovableModelOnPositionChanged;
            _bulletModel.SpawnableModel.AddedToPool += SpawnableModelOnAddedToPool;
            _bulletView.OnSpawned(_bulletModel.MovableModel.Position);
        }

        private void MovableModelOnPositionChanged(Vector2 position)
        {
            _bulletView.SetPosition(position);
        }

        public void RequestAddToPool()
        {
            _spawnableService.AddToPool(_bulletModel.SpawnableModel);
        }

        public void RequestDeltaMode(float deltaTime)
        {
            _movableService.MoveDelta(_bulletModel.MovableModel, deltaTime);
        }
        
        public void Dispose()
        {
            _bulletModel.MovableModel.PositionChanged -= MovableModelOnPositionChanged;
            _bulletModel.SpawnableModel.Spawned -= SpawnableModelOnSpawned;
            _bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
        }
    }
}