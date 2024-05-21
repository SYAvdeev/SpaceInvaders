using UnityEngine;

namespace SpaceInvaders.AssetsSpawn
{
    [CreateAssetMenu(fileName ="AddressablesPrototypesConfig", menuName = "Custom/Assets/Addressables Prototypes Config", order = 0)]
    public class AddressablesPrototypesConfig : ScriptableObject
    {
        [SerializeField]
        private PrototypeDictionary _prototypeDictionary;

        public PrototypeDictionary PrototypeDictionary => _prototypeDictionary;
    }
}