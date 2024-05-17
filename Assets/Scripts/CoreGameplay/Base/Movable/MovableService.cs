namespace SpaceInvaders.CoreGameplay.Base.Movable
{
    public class MovableService
    {
        public void MoveDelta(MovableModel movableModel, float deltaTime)
        {
            movableModel.Position += movableModel.Speed * deltaTime * movableModel.DirectionNormalized;
        }
    }
}