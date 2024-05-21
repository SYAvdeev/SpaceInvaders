using UnityEngine;
using Zenject;

namespace SpaceInvaders.Application
{
    [CreateAssetMenu(fileName = nameof(ConfigsRepository), menuName = "Custom/" + nameof(ConfigsRepository))]
    public sealed class ConfigsRepository : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _configsScriptableObjects;

        public void Configure(DiContainer container)
        {
            foreach (ScriptableObject configScriptableObject in _configsScriptableObjects)
            {
                if (configScriptableObject == null) continue; // Check missing reference

                container.Bind(configScriptableObject.GetType()).FromInstance(configScriptableObject).AsSingle();
            }
        }
    }
}