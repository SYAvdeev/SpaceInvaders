using System.Linq;
using UnityEngine;

namespace SpaceInvaders.UI.UI
{
    [CreateAssetMenu(fileName = nameof(UIConfig), menuName = "Custom/UI/" + nameof(UIConfig), order = 1)]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private UIScreen[] _uiScreenPrefabs;

        public TScreen GetUIPrefabByType<TScreen>() where TScreen : UIScreen => (TScreen)_uiScreenPrefabs.FirstOrDefault(s => s is TScreen);
    }
}