using UnityEngine;

namespace SpaceInvaders.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Custom/Gameplay/" + nameof(PlayerConfig), order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private string _playerSpawnID;

        public string PlayerSpawnID => _playerSpawnID;
    }
}