using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletModel
    {
        public BulletData BulletData { get; }
        public MovableModel MovableModel { get; }
        public SpawnableModel SpawnableModel { get; }

        public BulletModel(BulletData bulletData, MovableModel movableModel, SpawnableModel spawnableModel)
        {
            BulletData = bulletData;
            MovableModel = movableModel;
            SpawnableModel = spawnableModel;
        }
    }
}