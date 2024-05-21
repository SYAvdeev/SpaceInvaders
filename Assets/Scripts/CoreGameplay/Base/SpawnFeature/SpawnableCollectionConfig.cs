using System.Linq;
using Sirenix.Serialization;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnFeature
{
    public abstract class SpawnableCollectionConfig<TData> : ScriptableObject
        where TData : SpawnableData
    {
        [OdinSerialize] public ScriptableObject[] _configs;

        public bool GetByID(string id, out SpawnableConfig<TData> spawnableConfig)
        {
            spawnableConfig = (SpawnableConfig<TData>)_configs.FirstOrDefault(config => config is SpawnableConfig<TData> spawnableConfig && spawnableConfig.ID == id);
            return spawnableConfig != null;
        }
    }
}