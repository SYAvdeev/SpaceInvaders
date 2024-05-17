using System;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Movable
{
    [Serializable]
    public class MovableData
    {
        public Vector2 Position;
        public Vector2 DirectionNormalized;
        public float Speed;
    }
}