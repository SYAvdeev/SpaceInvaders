using System;
using SpaceInvaders.CoreGameplay.Base.Movable;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    [Serializable]
    public class BulletData
    {
        public string ID;
        public MovableData MovableData;
    }
}