using Zenject;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public class SpawnableModelFactory<TData, TModel> : PlaceholderFactory<TData, TModel>
        where TData : SpawnableData
        where TModel : SpawnableModel
    {
        
    }
}