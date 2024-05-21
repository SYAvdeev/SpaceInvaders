
using SpaceInvaders.Scenes.Scenes;
using SpaceInvaders.UI.UI;
using Zenject;

namespace SpaceInvaders.Bootstrap
{
    public class BootstrapSceneStarter : IInitializable
    {
        private readonly UIService _uiService;
        private readonly ScenesService _scenesService;

        public BootstrapSceneStarter(UIService uiService, ScenesService scenesService)
        {
            _uiService = uiService;
            _scenesService = scenesService;
        }

        public async void Initialize()
        {
            await _uiService.ShowScreen<LoadingScreen>(true, null);
            await _scenesService.LoadGameplayScene(false);
        }
    }
}
