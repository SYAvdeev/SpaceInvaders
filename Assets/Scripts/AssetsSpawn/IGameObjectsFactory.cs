using UnityEngine;

namespace SpaceInvaders.AssetsSpawn
{
    public interface IGameObjectsFactory
    {
        GameObject Instantiate(GameObject original);
        GameObject Instantiate(GameObject original, Transform parent);
        //GameObject Instantiate(GameObject original, Transform parent, bool worldPositionStays);
        GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent = null);
        void Destroy(GameObject obj);
    }
}