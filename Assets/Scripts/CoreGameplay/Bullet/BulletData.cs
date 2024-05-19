﻿using System;
using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    [Serializable]
    public class BulletData : SpawnableDataBase
    {
        public MovableData MovableData;
    }
}