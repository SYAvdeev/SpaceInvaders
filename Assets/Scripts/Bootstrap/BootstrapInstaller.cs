using SpaceInvaders.AssetsSpawn;
using SpaceInvaders.UI.UI;
using SpaceInvaders.Utility.Services;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectsPoolService _gameObjectsPoolService;
        [SerializeField] private UIViewRoot _uiViewRoot;
        
        public override void InstallBindings()
        {
            BindAssetsSpawnService();
            ConfigureUI();
            Container.Bind<IInitializable>().To<BootstrapSceneStarter>().AsSingle().NonLazy();
        }
        
        private void ConfigureUI()
        {
            DontDestroyOnLoad(_uiViewRoot.gameObject);
            Container.Bind<UIViewRoot>().FromInstance(_uiViewRoot).AsSingle();
            Container.Bind<UIModel>().To<UIModel>().AsSingle();
            Container.Bind<UIService>().To<UIService>().AsSingle();
        }
        
        private void BindAssetsSpawnService()
        {
            Container.Bind<IGameObjectsFactory>().To<GameObjectsFactory>().AsSingle();
            Container.Bind<IPrototypeProvider>().To<AddressablesPrototypeProvider>().AsSingle();
            Container.Bind<IPoolService<string, GameObject>>().FromInstance(_gameObjectsPoolService).AsSingle();
            Container.Bind<IAssetsSpawnService>().To<AssetsSpawnService>().AsSingle();
        }
    }
}