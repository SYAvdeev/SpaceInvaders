using System;
using System.Collections.Generic;
using SpaceInvaders.Utility;

namespace SpaceInvaders.CoreGameplay.Bullet.Spawn
{
    public class BulletSpawnModel
    {
        internal Pool<string, BulletModel> BulletsPool { get; } = new();
        internal List<BulletModel> CurrentBullets { get; } = new();

        internal event Action<BulletModel> BulletAdded;
        internal event Action<BulletModel> BulletRemoved;

        internal void FireBulletAddedEvent(BulletModel bulletModel)
        {
            BulletAdded?.Invoke(bulletModel);
        }
        
        internal void FireBulletRemovedEvent(BulletModel bulletModel)
        {
            BulletRemoved?.Invoke(bulletModel);
        }
    }
}