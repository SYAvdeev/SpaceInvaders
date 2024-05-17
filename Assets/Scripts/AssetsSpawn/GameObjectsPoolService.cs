using System.Collections.Generic;
using SpaceInvaders.Utility.Services;
using UnityEngine;

namespace SpaceInvaders.AssetsSpawn
{
    public class GameObjectsPoolService : MonoBehaviour, IPoolService<string, GameObject>
    {
        [SerializeField]
        private Transform _parent;
        
        private readonly IDictionary<string, Stack<GameObject>> _dictionary
            = new Dictionary<string, Stack<GameObject>>();

        public bool TryGet(string key, out GameObject value)
        {
            if (_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects) && gameObjects.Count > 0)
            {
                value = gameObjects.Pop();
                value.SetActive(true);
                return true;
            }

            value = null;
            return false;
        }

        public void Add(string key, GameObject value)
        {
            if (!_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects))
            {
                gameObjects = _dictionary[key] = new Stack<GameObject>();
            }
            
            gameObjects.Push(value);
            value.transform.parent = _parent;
            value.SetActive(false);
        }

        public void Prewarm(string key, int count)
        {
            
        }
    }
}