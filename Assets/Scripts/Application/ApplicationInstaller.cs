using SpaceInvaders.Scenes.Scenes;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        [SerializeField] private ConfigsRepository _configsRepository;
        
        public override void InstallBindings()
        {
            BindConfigs();
            ConfigureScenes();
        }
        
        private void BindConfigs()
        {
            _configsRepository.Configure(Container);
        }

        private void ConfigureScenes()
        {
            Container.Bind<ScenesModel>().To<ScenesModel>().AsSingle();
            Container.Bind<ScenesService>().To<ScenesService>().AsSingle();
        }
    }
}