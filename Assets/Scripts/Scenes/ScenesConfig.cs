using UnityEngine;

namespace SpaceInvaders.Scenes.Scenes
{
    [CreateAssetMenu(fileName = nameof(ScenesConfig), menuName = "Custom/Scenes/" + nameof(ScenesConfig), order = 1)]
    public class ScenesConfig  : ScriptableObject
    {
        [SerializeField] private int _lobbySceneIndex;

        public int LobbySceneIndex => _lobbySceneIndex;
    }
}