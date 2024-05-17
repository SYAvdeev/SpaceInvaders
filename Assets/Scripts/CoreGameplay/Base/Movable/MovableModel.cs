using System;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Movable
{
    public class MovableModel
    {
        private readonly MovableData _movableData;
        public event Action<Vector2> PositionChanged;
        
        public Vector2 Position
        {
            get => _movableData.Position;
            internal set
            {
                _movableData.Position = value;
                PositionChanged?.Invoke(value);
            }
        }

        public float Speed => _movableData.Speed;
        public Vector2 DirectionNormalized => _movableData.DirectionNormalized;

        public MovableModel(MovableData movableData)
        {
            _movableData = movableData;
        }
    }
}