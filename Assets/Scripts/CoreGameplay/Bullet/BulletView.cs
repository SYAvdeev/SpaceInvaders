using System.Threading;
using Cysharp.Threading.Tasks;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using SpaceInvaders.Utility;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.CoreGameplay.Bullet
{
    public class BulletView : MonoBehaviour, ISpawnableView
    {
        [SerializeField] private Transform _transform;
        [Inject] private GameplayConfig _gameplayConfig;
        
        private BulletPresenter _bulletPresenter;
        private UniTaskRestartable _moveTask;

        public Transform Transform => _transform;

        public void Initialize(BulletPresenter bulletPresenter)
        {
            _bulletPresenter = bulletPresenter;
            _moveTask = new UniTaskRestartable(MoveTask);
        }
        
        public void AddToPool()
        {
            _bulletPresenter.RequestAddToPool();
        }
        
        public void OnSpawned(Vector2 position)
        {
            SetPosition(position);
            _moveTask.Restart();
        }

        public void SetPosition(Vector2 position)
        {
            _transform.localPosition = position;
        }

        public void OnAddedToPool()
        {
            gameObject.SetActive(false);
            _moveTask.Cancel();
        }

        private async UniTask MoveTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _bulletPresenter.RequestDeltaMode(Time.deltaTime);
                await UniTask.Yield(cancellationToken);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_gameplayConfig.HasDestructibleTag(collision.gameObject.tag))
            {
                ISpawnableView spawnableView = collision.gameObject.GetComponent<ISpawnableView>();
                spawnableView.AddToPool();
                AddToPool();
            }
        }
    }
}