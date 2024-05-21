using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnFeature
{
    public class SpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _spawnableParent;
        [SerializeField] private Transform _spawnablePoolParent;

        public Transform SpawnableParent => _spawnableParent;
        public Transform SpawnablePoolParent => _spawnablePoolParent;
    }
}