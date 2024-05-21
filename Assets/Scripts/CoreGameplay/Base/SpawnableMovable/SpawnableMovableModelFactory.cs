using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using Zenject;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnableMovableModelFactory : SpawnableModelFactory<SpawnableMovableData, SpawnableMovableModel>
    {
        private readonly PlaceholderFactory<SpawnableMovableData, MovableModel, SpawnableMovableModel> _placeholderFactory;
        private readonly MovableModelFactory _movableModelFactory;

        public SpawnableMovableModelFactory(PlaceholderFactory<SpawnableMovableData, MovableModel, SpawnableMovableModel> placeholderFactory, MovableModelFactory movableModelFactory)
        {
            _placeholderFactory = placeholderFactory;
            _movableModelFactory = movableModelFactory;
        }

        public override SpawnableMovableModel Create(SpawnableMovableData spawnableMovableData)
        {
            MovableModel movableModel = _movableModelFactory.Create(spawnableMovableData.MovableData);
            return _placeholderFactory.Create(spawnableMovableData, movableModel);
        }
    }
}