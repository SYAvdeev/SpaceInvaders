using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletsSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _bulletsParent;
        [SerializeField] private Transform _bulletsPoolParent;

        public Transform BulletsParent => _bulletsParent;
        public Transform BulletsPoolParent => _bulletsPoolParent;
    }
}