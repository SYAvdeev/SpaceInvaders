using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnableMovablePresenter : SpawnablePresenter
    {
        private readonly MovableService _movableService;
        private SpawnableMovableModel SpawnableMovableModel => (SpawnableMovableModel)_spawnableModel;
        private SpawnableMovableView SpawnableMovableView => (SpawnableMovableView)_spawnableView; 
        
        public SpawnableMovablePresenter(
            SpawnableMovableModel spawnableMovableModel,
            SpawnableMovableView spawnableMovableView) : base(spawnableMovableModel, spawnableMovableView) { }

        protected override void SpawnableModelOnSpawned(SpawnableModel spawnableModel)
        {
            base.SpawnableModelOnSpawned(spawnableModel);
            SpawnableMovableModel.MovableModel.PositionChanged -= MovableModelOnPositionChanged;
            SpawnableMovableView.OnSpawned(SpawnableMovableModel.MovableModel.Position);
        }
        
        private void MovableModelOnPositionChanged(Vector2 position)
        {
            SpawnableMovableView.SetPosition(position);
        }
        
        public void RequestDeltaMove(float deltaTime)
        {
            _movableService.MoveDelta(SpawnableMovableModel.MovableModel, deltaTime);
        }
        
        public override void Dispose()
        {
            base.Dispose();
            SpawnableMovableModel.MovableModel.PositionChanged -= MovableModelOnPositionChanged;
        }
    }
}