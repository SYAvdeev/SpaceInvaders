using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using Zenject;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletModelFactory : PlaceholderFactory<BulletData, MovableModel, SpawnableModel , BulletModel>
    {
        private readonly MovableModelFactory _movableModelFactory;
        private readonly SpawnableModelFactory _spawnableModelFactory;

        public BulletModelFactory(MovableModelFactory movableModelFactory, SpawnableModelFactory spawnableModelFactory)
        {
            _movableModelFactory = movableModelFactory;
            _spawnableModelFactory = spawnableModelFactory;
        }

        public BulletModel Create(BulletConfig bulletConfig)
        {
            MovableModel movableModel = _movableModelFactory.Create(bulletConfig.InitialData.MovableData);
            SpawnableModel spawnableModel = _spawnableModelFactory.Create();
            return base.Create(bulletConfig.InitialData, movableModel, spawnableModel);
        }
    }
}