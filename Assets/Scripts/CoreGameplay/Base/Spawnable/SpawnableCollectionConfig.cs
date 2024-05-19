using System.Linq;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public abstract class SpawnableCollectionConfig<TConfig, TData> : ScriptableObject 
        where TData : SpawnableDataBase
        where TConfig : SpawnableConfigBase<TData>
    {
        [SerializeField] protected TConfig[] _configs;

        public bool GetByID(string id, out TConfig config)
        {
            config = _configs.FirstOrDefault(b => b.InitialData.ID == id);
            return config != null;
        }
    }
}