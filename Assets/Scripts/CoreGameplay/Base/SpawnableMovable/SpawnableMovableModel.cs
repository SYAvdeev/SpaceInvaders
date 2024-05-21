using SpaceInvaders.CoreGameplay.Base.Movable;
using SpaceInvaders.CoreGameplay.Base.Spawnable;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnableMovableModel : SpawnableModel
    {
        public new SpawnableMovableData Data => (SpawnableMovableData)base.Data;
        public MovableModel MovableModel { get; }

        public SpawnableMovableModel(SpawnableMovableData data, MovableModel movableModel) : base(data)
        {
            MovableModel = movableModel;
        }
    }
}