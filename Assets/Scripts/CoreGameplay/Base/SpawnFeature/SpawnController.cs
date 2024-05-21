using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SpaceInvaders.AssetsSpawn;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using Zenject;

namespace SpaceInvaders.CoreGameplay.Base.SpawnFeature
{
    public class SpawnController : IInitializable, IDisposable
    {
        private readonly SpawnView _spawnView;
        private readonly SpawnModel _spawnModel;
        private readonly IAssetsSpawnService _assetsSpawnService;
        private readonly SpawnablePresenterFactory _spawnablePresenterFactory;

        private readonly Dictionary<SpawnableModel, SpawnableView> _spawnableViews = new();

        public SpawnController(SpawnView spawnView, SpawnModel spawnModel, IAssetsSpawnService assetsSpawnService, SpawnablePresenterFactory spawnablePresenterFactory)
        {
            _spawnView = spawnView;
            _spawnModel = spawnModel;
            _assetsSpawnService = assetsSpawnService;
            _spawnablePresenterFactory = spawnablePresenterFactory;
        }

        public void Initialize()
        {
            _spawnModel.SpawnableAdded += SpawnModelOnSpawnableAdded;
            _spawnModel.SpawnableRemoved += SpawnModelOnSpawnableRemoved;
        }

        private async void SpawnModelOnSpawnableAdded(SpawnableModel spawnableModel)
        {
            await SpawnViewInternal(spawnableModel);
            spawnableModel.FireSpawnedEvent();
        }

        protected virtual async UniTask<SpawnableView> SpawnViewInternal(SpawnableModel spawnableModel)
        {
            if (!_spawnableViews.TryGetValue(spawnableModel, out SpawnableView spawnableView))
            {
                spawnableView = await _assetsSpawnService.Spawn<SpawnableView>(
                    spawnableModel.Data.ID,
                    _spawnView.SpawnableParent);

                SpawnablePresenter spawnablePresenter = _spawnablePresenterFactory.Create(spawnableModel, spawnableView);
                spawnableView.Initialize(spawnablePresenter);

                _spawnableViews[spawnableModel] = spawnableView;
            }
            else
            {
                spawnableView.Transform.SetParent(_spawnView.SpawnableParent);
            }

            return spawnableView;
        }

        private void SpawnModelOnSpawnableRemoved(SpawnableModel spawnableModel)
        {
            _spawnableViews[spawnableModel].Transform.SetParent(_spawnView.SpawnablePoolParent);
        }

        public void Dispose()
        {
            _spawnModel.SpawnableAdded -= SpawnModelOnSpawnableAdded;
            _spawnModel.SpawnableRemoved -= SpawnModelOnSpawnableRemoved;
        }
    }
}