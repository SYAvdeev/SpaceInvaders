using System;
using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Enemy
{
    [Serializable]
    public class EnemyData : SpawnableDataBase
    {
        public string BulletID;
        public MovableData MovableData;
    }
}