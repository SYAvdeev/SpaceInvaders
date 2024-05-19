using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Enemy
{
    public class EnemyModel
    {
        public EnemyData EnemyData { get; }
        public MovableModel MovableModel { get; }
        public SpawnableModel SpawnableModel { get; }

        public EnemyModel(EnemyData enemyData, MovableModel movableModel, SpawnableModel spawnableModel)
        {
            EnemyData = enemyData;
            MovableModel = movableModel;
            SpawnableModel = spawnableModel;
        }
    }
}