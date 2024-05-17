using System.Linq;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay
{
    public class GameplayConfig : ScriptableObject
    {
        [SerializeField] private string[] _destructibleObjectsTags;

        public bool HasDestructibleTag(string tag) => _destructibleObjectsTags.Contains(tag);
    }
}