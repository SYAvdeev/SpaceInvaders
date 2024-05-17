using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SpaceInvaders.Scenes.Scenes
{
    public class ScenesService
    {
        private readonly ScenesConfig _scenesConfig;
        private readonly ScenesModel _scenesModel;

        public ScenesService(ScenesConfig scenesConfig, ScenesModel scenesModel)
        {
            _scenesConfig = scenesConfig;
            _scenesModel = scenesModel;
        }

        public async UniTask LoadScene(int sceneIndex, bool unloadCurrentScene = true)
        {
            if (unloadCurrentScene)
            {
                await SceneManager.UnloadSceneAsync(_scenesModel.CurrentSceneIndex);
            }

            _scenesModel.CurrentSceneIndex = sceneIndex;
            await SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        }
        
        public async UniTask LoadLobbyScene(bool unloadCurrentScene = true)
        {
            await LoadScene(_scenesConfig.LobbySceneIndex, unloadCurrentScene);
        }
    }
}