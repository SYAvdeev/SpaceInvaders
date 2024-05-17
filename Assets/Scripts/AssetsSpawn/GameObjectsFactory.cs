using UnityEngine;
using Zenject;

namespace SpaceInvaders.AssetsSpawn
{
    public class GameObjectsFactory : IGameObjectsFactory
    {
        private readonly DiContainer _diContainer;

        public GameObjectsFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject Instantiate(GameObject original) => _diContainer.InstantiatePrefab(original);

        public GameObject Instantiate(GameObject original, Transform parent) => _diContainer.InstantiatePrefab(original, parent);

        public GameObject Instantiate(
            GameObject original,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null) =>
            _diContainer.InstantiatePrefab(original, position, rotation, parent);

        public void Destroy(GameObject obj)
        {
            Object.Destroy(obj);
        }
    }
}