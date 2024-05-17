using System;
using System.Collections.Generic;
using SpaceInvaders.AssetsSpawn;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletSpawnController : IDisposable
    {
        private readonly BulletSpawnView _bulletSpawnView;
        private readonly BulletSpawnModel _bulletSpawnModel;
        private readonly IAssetsSpawnService _assetsSpawnService;
        private readonly BulletPresenterFactory _bulletPresenterFactory;

        private readonly Dictionary<BulletModel, BulletView> _bulletViews = new();

        public BulletSpawnController(BulletSpawnView bulletSpawnView, BulletSpawnModel bulletSpawnModel, IAssetsSpawnService assetsSpawnService, BulletPresenterFactory bulletPresenterFactory)
        {
            _bulletSpawnView = bulletSpawnView;
            _bulletSpawnModel = bulletSpawnModel;
            _assetsSpawnService = assetsSpawnService;
            _bulletPresenterFactory = bulletPresenterFactory;
        }

        public void Initialize()
        {
            _bulletSpawnModel.BulletAdded += BulletSpawnModelOnBulletAdded;
            _bulletSpawnModel.BulletRemoved += BulletSpawnModelOnBulletRemoved;
        }

        private async void BulletSpawnModelOnBulletAdded(BulletModel bulletModel)
        {
            if (!_bulletViews.TryGetValue(bulletModel, out BulletView bulletView))
            {
                bulletView = await _assetsSpawnService.Spawn<BulletView>(
                    bulletModel.BulletData.ID,
                    bulletModel.BulletData.MovableData.Position,
                    Quaternion.identity,
                    _bulletSpawnView.BulletsParent);

                BulletPresenter bulletPresenter = _bulletPresenterFactory.Create(bulletModel, bulletView);
                bulletView.Initialize(bulletPresenter);

                _bulletViews[bulletModel] = bulletView;
            }
            else
            {
                bulletView.Transform.SetParent(_bulletSpawnView.BulletsParent);
            }
            
            bulletModel.SpawnableModel.FireSpawnedEvent();
        }
        
        private void BulletSpawnModelOnBulletRemoved(BulletModel bulletModel)
        {
            _bulletViews[bulletModel].Transform.SetParent(_bulletSpawnView.BulletsParent);
        }

        public void Dispose()
        {
            _bulletSpawnModel.BulletAdded -= BulletSpawnModelOnBulletAdded;
            _bulletSpawnModel.BulletRemoved -= BulletSpawnModelOnBulletRemoved;
        }
    }
}