using System.Threading;
using Cysharp.Threading.Tasks;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using SpaceInvaders.CoreGameplay.Base.SpawnableMovable;
using SpaceInvaders.Utility;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletView : SpawnableMovableView
    {
        [Inject] private GameplayConfig _gameplayConfig;
        
        private UniTaskRestartable _moveTask;

        public override void Initialize(SpawnablePresenter spawnablePresenter)
        {
            base.Initialize(spawnablePresenter);
            _moveTask = new UniTaskRestartable(MoveTask);
        }
        
        public override void OnSpawned(Vector2 position)
        {
            base.OnSpawned(position);
            _moveTask.Restart();
        }

        public override void OnAddedToPool()
        {
            _moveTask.Cancel();
        }

        private async UniTask MoveTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _spawnableMovablePresenter.RequestDeltaMove(Time.deltaTime);
                await UniTask.Yield(cancellationToken);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_gameplayConfig.HasDestructibleTag(collision.gameObject.tag))
            {
                SpawnableView spawnableView = collision.gameObject.GetComponent<SpawnableView>();
                spawnableView.AddToPool();
                AddToPool();
            }
        }
    }
}