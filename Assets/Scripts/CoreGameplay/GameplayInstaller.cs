using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using SpaceInvaders.CoreGameplay.Base.SpawnableMovable;
using SpaceInvaders.CoreGameplay.Base.SpawnFeature;
using SpaceInvaders.Player;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.CoreGameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private SpawnView _spawnView;
        
        public override void InstallBindings()
        {
            ConfigureSpawn();
            ConfigurePlayer();
        }

        private void ConfigureSpawn()
        {
            Container.Bind<SpawnModel>().To<SpawnModel>().AsSingle();
            Container.BindFactory<MovableData, MovableModel, MovableModelFactory>().AsSingle();
            Container.BindFactory<
                    SpawnableMovableData,
                    MovableModel, 
                    SpawnableMovableModel,
                    PlaceholderFactory<SpawnableMovableData, MovableModel, SpawnableMovableModel>>().AsSingle();
            Container.BindFactory<SpawnableMovableData, SpawnableMovableModel, SpawnableMovableModelFactory>().AsSingle();
            Container.Bind<SpawnMovableService>().To<SpawnMovableService>().AsSingle();
            Container.BindFactory<SpawnableModel, SpawnableView, SpawnablePresenter, SpawnablePresenterFactory>().AsSingle();
            Container.BindInstance(_spawnView).AsSingle();
            Container.Bind<IInitializable>().To<SpawnMovableController>().AsSingle();
        }
        
        private void ConfigurePlayer()
        {
            Container.Bind<IInitializable>().To<PlayerService>().AsSingle();
        }
    }
}