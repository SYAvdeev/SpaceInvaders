using System;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletsSpawnService  : IDisposable
    {
        private readonly BulletModelFactory _bulletModelFactory;
        private readonly BulletSpawnModel _bulletSpawnModel;

        public BulletsSpawnService(BulletModelFactory bulletModelFactory, BulletSpawnModel bulletSpawnModel)
        {
            _bulletModelFactory = bulletModelFactory;
            _bulletSpawnModel = bulletSpawnModel;
        }

        public void Spawn(BulletConfig bulletConfig, Vector2 position, Vector2 direction)
        {
            if(_bulletSpawnModel.BulletsPool.TryGet(bulletConfig.InitialData.ID, out BulletModel bulletModel))
            {
                bulletModel = _bulletModelFactory.Create(bulletConfig);
                bulletModel.BulletData.MovableData.Position = position;
                bulletModel.BulletData.MovableData.DirectionNormalized = direction;
                
            }
            
            bulletModel.SpawnableModel.AddedToPool += SpawnableModelOnAddedToPool;
            _bulletSpawnModel.CurrentBullets.Add(bulletModel);
            _bulletSpawnModel.FireBulletAddedEvent(bulletModel);
        }

        private void SpawnableModelOnAddedToPool(SpawnableModel spawnableModel)
        {
            BulletModel bulletModel = _bulletSpawnModel.CurrentBullets.Find(b => b.SpawnableModel == spawnableModel);
            _bulletSpawnModel.CurrentBullets.Remove(bulletModel);
            _bulletSpawnModel.BulletsPool.Add(bulletModel.BulletData.ID, bulletModel);
            _bulletSpawnModel.FireBulletRemovedEvent(bulletModel);
            bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
        }

        public void Dispose()
        {
            foreach (BulletModel bulletModel in _bulletSpawnModel.CurrentBullets)
            {
                bulletModel.SpawnableModel.AddedToPool -= SpawnableModelOnAddedToPool;
            }
        }
    }
}