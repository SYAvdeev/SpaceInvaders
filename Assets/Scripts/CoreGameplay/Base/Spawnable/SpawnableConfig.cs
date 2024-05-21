using System;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    [Serializable]
    public abstract class SpawnableConfig<TData> : ScriptableObject
        where TData : SpawnableData
    {
        [SerializeField] private TData _initialData;
        public string ID => _initialData.ID;
        public TData CopyData() => (TData)_initialData.Clone();
    }
}