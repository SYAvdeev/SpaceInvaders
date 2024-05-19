using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public abstract class SpawnableConfigBase<TData> : ScriptableObject where TData : SpawnableDataBase
    {
        [SerializeField] private TData _initialData;
        
        public TData InitialData => _initialData;
    }
}