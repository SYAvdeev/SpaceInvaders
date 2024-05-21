using SpaceInvaders.CoreGameplay.Base.Spawnable;
using UnityEngine;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnableMovableView : SpawnableView
    {
        protected SpawnableMovablePresenter _spawnableMovablePresenter => (SpawnableMovablePresenter)_spawnablePresenter;
        
        public override void AddToPool()
        {
            _spawnablePresenter.RequestAddToPool();
        }
        
        public virtual void OnSpawned(Vector2 position)
        {
            SetPosition(position);
        }

        public void SetPosition(Vector2 position)
        {
            _transform.localPosition = position;
        }
    }
}