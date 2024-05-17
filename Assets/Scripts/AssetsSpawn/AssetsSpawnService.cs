using Cysharp.Threading.Tasks;
using SpaceInvaders.Utility.Services;
using UnityEngine;

namespace SpaceInvaders.AssetsSpawn
{
    public class AssetsSpawnService : IAssetsSpawnService
    {
        private readonly IPoolService<string, GameObject> _gameObjectsPool;
        private readonly IPrototypeProvider _prototypeProvider;
        private readonly IGameObjectsFactory _gameObjectsFactory;

        public AssetsSpawnService(
            IPoolService<string, GameObject> gameObjectsPool,
            IPrototypeProvider prototypeProvider,
            IGameObjectsFactory gameObjectsFactory)
        {
            _gameObjectsPool = gameObjectsPool;
            _prototypeProvider = prototypeProvider;
            _gameObjectsFactory = gameObjectsFactory;
        }

        public async UniTask<T> Spawn<T>(string key) where T : Component
        {
            if (_gameObjectsPool.TryGet(key, out GameObject gameObject))
            {
                return gameObject.GetComponent<T>();
            }

            T prototype = await _prototypeProvider.Get<T>(key);
            gameObject = _gameObjectsFactory.Instantiate(prototype.gameObject);

            return gameObject.GetComponent<T>();
        }

        public async UniTask<T> Spawn<T>(string key, Transform parent) where T : Component
        {
            if (_gameObjectsPool.TryGet(key, out GameObject gameObject))
            {
                gameObject.transform.parent = parent;
                return gameObject.GetComponent<T>();
            }

            T prototype = await _prototypeProvider.Get<T>(key);
            gameObject = _gameObjectsFactory.Instantiate(prototype.gameObject, parent);

            return gameObject.GetComponent<T>();
        }

        public async UniTask<T> Spawn<T>(string key, Vector3 position, Quaternion rotation, Transform parent = null) 
            where T : Component
        {
            if (_gameObjectsPool.TryGet(key, out GameObject gameObject))
            {
                gameObject.transform.localPosition = position;
                gameObject.transform.localRotation = rotation;
                gameObject.transform.parent = parent;
                return gameObject.GetComponent<T>();
            }

            T prototype = await _prototypeProvider.Get<T>(key);
            gameObject = _gameObjectsFactory.Instantiate(prototype.gameObject, position, rotation, parent);

            return gameObject.GetComponent<T>();
        }

        public async UniTask Prewarm<T>(string key, int count) where T : Component
        {
            for (int i = 0; i < count; i++)
            {
                T spawnedObject = await Spawn<T>(key);
                AddToPool(spawnedObject, key);
            }
        }

        public void Destroy<T>(T asset) where T : Component
        {
            _gameObjectsFactory.Destroy(asset.gameObject);
        }

        public void AddToPool<T>(T asset, string key) where T : Component
        {
            _gameObjectsPool.Add(key, asset.gameObject);
        }
    }
}