using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SpaceInvaders.AssetsSpawn
{
    public interface IAssetsSpawnService
    {
        UniTask<T> Spawn<T>(string key) where T : Component;
        UniTask<T> Spawn<T>(string key, Transform parent) where T : Component;
        UniTask<T> Spawn<T>(string key, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
        UniTask Prewarm<T>(string key, int count) where T : Component;
        void Destroy<T>(T asset) where T : Component;
        void AddToPool<T>(T asset, string key) where T : Component;
    }
}