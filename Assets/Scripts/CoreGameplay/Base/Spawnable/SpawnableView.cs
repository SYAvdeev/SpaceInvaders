using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    public abstract class SpawnableView : MonoBehaviour
    {
        [SerializeField] protected Transform _transform;
        
        protected SpawnablePresenter _spawnablePresenter;

        public Transform Transform => _transform;

        public abstract void AddToPool();

        public virtual void Initialize(SpawnablePresenter spawnablePresenter)
        {
            _spawnablePresenter = spawnablePresenter;
        }

        public virtual void OnAddedToPool()
        {
            gameObject.SetActive(false);
        }
    }
}