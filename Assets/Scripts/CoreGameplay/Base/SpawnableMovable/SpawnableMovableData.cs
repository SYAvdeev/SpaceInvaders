using System;
using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    [Serializable]
    public class SpawnableMovableData : SpawnableData
    {
        public MovableData MovableData;
    }
}