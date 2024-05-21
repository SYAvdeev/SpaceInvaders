using SpaceInvaders.CoreGameplay.Base.SpawnFeature;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    [CreateAssetMenu(fileName = nameof(SpawnableMovableCollectionConfig), menuName = "Custom/Spawn/" + nameof(SpawnableMovableCollectionConfig), order = 0)]
    public class SpawnableMovableCollectionConfig : SpawnableCollectionConfig<SpawnableMovableData>
    {
        
    }
}