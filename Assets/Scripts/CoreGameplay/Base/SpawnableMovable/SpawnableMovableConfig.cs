using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    [CreateAssetMenu(fileName = nameof(SpawnableMovableConfig), menuName = "Custom/Spawn/" + nameof(SpawnableMovableConfig), order = 0)]
    public class SpawnableMovableConfig : SpawnableConfig<SpawnableMovableData>
    {
        
    }
}