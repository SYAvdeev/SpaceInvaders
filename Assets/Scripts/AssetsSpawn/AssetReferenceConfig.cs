using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SpaceInvaders.AssetsSpawn
{
    [CreateAssetMenu(fileName = nameof(AssetReferenceConfig), menuName = "Custom/Assets/" + nameof(AssetReferenceConfig), order = 0)]
    public class AssetReferenceConfig : ScriptableObject
    {
        [SerializeField]
        private AssetReference assetReference;

        public AssetReference AssetReference => assetReference;
    }
}