using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace SpaceInvaders.UI.UI
{
    public class UIService
    {
        private readonly UIModel _uiModel;
        private readonly UIConfig _uiConfig;
        private readonly UIViewRoot _uiViewRoot;
        private readonly IInstantiator _instantiator;

        public UIService(UIModel uiModel, UIConfig uiConfig, UIViewRoot uiViewRoot, IInstantiator instantiator)
        {
            _uiModel = uiModel;
            _uiConfig = uiConfig;
            _uiViewRoot = uiViewRoot;
            _instantiator = instantiator;
        }

        public async UniTask<TScreen> ShowScreen<TScreen>(
            bool isImmediate,
            Action<TScreen> initializeCallback = null,
            Action<TScreen> beforeShowCallback = null) where TScreen : UIScreen
        {
            string screenName = typeof(TScreen).FullName;
            if (_uiModel.CurrentOpenedScreens.ContainsKey(screenName))
            {
                return (TScreen)_uiModel.CurrentOpenedScreens[screenName];
            }

            if (!_uiModel.ScreenPool.TryGet(screenName, out IUIScreen screen))
            {
                TScreen screenPrefab = _uiConfig.GetUIPrefabByType<TScreen>();
                screen = _instantiator.InstantiatePrefab(screenPrefab, _uiViewRoot.UIViewsParent).GetComponent<TScreen>();
                initializeCallback?.Invoke((TScreen)screen);
            }

            beforeShowCallback?.Invoke((TScreen)screen);
            await screen.Show(isImmediate);
            _uiModel.CurrentOpenedScreens.Add(screenName, screen);
            return (TScreen)screen;
        }

        public async UniTask HideScreen<TScreen>(bool isImmediate, Action<TScreen> beforeHideCallback = null) where TScreen : UIScreen
        {
            string screenName = typeof(TScreen).FullName;
            if (_uiModel.CurrentOpenedScreens.TryGetValue(screenName, out IUIScreen screen))
            {
                beforeHideCallback?.Invoke((TScreen)screen);
                await screen.Hide(isImmediate);
                _uiModel.CurrentOpenedScreens.Remove(screenName);
                _uiModel.ScreenPool.Add(screenName, screen);
            }
        }
    }
}