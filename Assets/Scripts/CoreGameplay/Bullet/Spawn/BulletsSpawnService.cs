using System;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletsSpawnService  : IDisposable
    {
        private readonly BulletModelFactory _bulletModelFactory;
        private readonly BulletsSpawnModel _bulletsSpawnModel;
        private readonly BulletsCollectionConfig _bulletsCollectionConfig;

        public BulletsSpawnService(BulletModelFactory bulletModelFactory, BulletsSpawnModel bulletsSpawnModel, BulletsCollectionConfig bulletsCollectionConfig)
        {
            _bulletModelFactory = bulletModelFactory;
            _bulletsSpawnModel = bulletsSpawnModel;
            _bulletsCollectionConfig = bulletsCollectionConfig;
        }

        public void Spawn(string bulletID, Vector2 position, Vector2 direction)
        {
            if(_bulletsSpawnModel.BulletsPool.TryGet(bulletID, out BulletModel bulletModel))
            {
                if (_bulletsCollectionConfig.GetByID(bulletID, out BulletConfig bulletConfig))
                {
                    bulletModel = _bulletModelFactory.Create(bulletConfig);
                    bulletModel.BulletData.MovableData.Position = position;
                    bulletModel.BulletData.MovableData.DirectionNormalized = direction;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            
            bulletModel.SpawnableModel.AddedToPool += SpawnableModelOnAddedToPool;
            _bulletsSpawnModel.CurrentBullets.Add(bulletModel);
            _bulletsSpawnModel.FireBulletAddedEvent(bulletModel);
        }

        private void SpawnableModelOnAddedToPool(SpawnableModel spawnableModel)
        {
            BulletModel bulletModel = _bulletsSpawnModel.CurrentBullets.Find(b => b.SpawnableModel == spawnableModel);
            _bulletsSpawnModel.CurrentBullets.Remove(bulletModel);
            _bulletsSpawnModel.BulletsPool.Add(bulletModel.BulletData.ID, bulletModel);
            _bulletsSpawnModel.FireBulletRemovedEvent(bulletModel);
            bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
        }

        public void Dispose()
        {
            foreach (BulletModel bulletModel in _bulletsSpawnModel.CurrentBullets)
            {
                bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
            }
        }
    }
}