using System;
using System.Collections.Generic;
using SpaceInvaders.AssetsSpawn;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletsSpawnController : IDisposable
    {
        private readonly BulletsSpawnView _bulletsSpawnView;
        private readonly BulletsSpawnModel _bulletsSpawnModel;
        private readonly IAssetsSpawnService _assetsSpawnService;
        private readonly BulletPresenterFactory _bulletPresenterFactory;

        private readonly Dictionary<BulletModel, BulletView> _bulletViews = new();

        public BulletsSpawnController(BulletsSpawnView bulletsSpawnView, BulletsSpawnModel bulletsSpawnModel, IAssetsSpawnService assetsSpawnService, BulletPresenterFactory bulletPresenterFactory)
        {
            _bulletsSpawnView = bulletsSpawnView;
            _bulletsSpawnModel = bulletsSpawnModel;
            _assetsSpawnService = assetsSpawnService;
            _bulletPresenterFactory = bulletPresenterFactory;
        }

        public void Initialize()
        {
            _bulletsSpawnModel.BulletAdded += BulletsSpawnModelOnBulletsAdded;
            _bulletsSpawnModel.BulletRemoved += BulletsSpawnModelOnBulletsRemoved;
        }

        private async void BulletsSpawnModelOnBulletsAdded(BulletModel bulletModel)
        {
            if (!_bulletViews.TryGetValue(bulletModel, out BulletView bulletView))
            {
                bulletView = await _assetsSpawnService.Spawn<BulletView>(
                    bulletModel.BulletData.ID,
                    bulletModel.BulletData.MovableData.Position,
                    Quaternion.identity,
                    _bulletsSpawnView.BulletsParent);

                BulletPresenter bulletPresenter = _bulletPresenterFactory.Create(bulletModel, bulletView);
                bulletView.Initialize(bulletPresenter);

                _bulletViews[bulletModel] = bulletView;
            }
            else
            {
                bulletView.Transform.SetParent(_bulletsSpawnView.BulletsParent);
            }
            
            bulletModel.SpawnableModel.FireSpawnedEvent();
        }
        
        private void BulletsSpawnModelOnBulletsRemoved(BulletModel bulletModel)
        {
            _bulletViews[bulletModel].Transform.SetParent(_bulletsSpawnView.BulletsParent);
        }

        public void Dispose()
        {
            _bulletsSpawnModel.BulletAdded -= BulletsSpawnModelOnBulletsAdded;
            _bulletsSpawnModel.BulletRemoved -= BulletsSpawnModelOnBulletsRemoved;
        }
    }
}