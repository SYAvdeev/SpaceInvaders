using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletConfig : ScriptableObject
    {
        [SerializeField] private BulletData _initialData;
        
        public BulletData InitialData => _initialData;
    }
}