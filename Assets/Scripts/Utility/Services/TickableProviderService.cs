using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SpaceInvaders.Utility.Services
{
    public class TickableProviderService : MonoBehaviour, IStartService, ITickProviderService
    {
        private CancellationTokenSource _cancellationToken;
        
        public event Action Start;
        public event Action<float> Tick;

        public async void StartTicks()
        {
            _cancellationToken = new CancellationTokenSource();
            await TicksRoutine(_cancellationToken.Token);
        }

        public void StopTicks()
        {
            if (_cancellationToken == null)
            {
                return;
            }
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
        }

        private async UniTask TicksRoutine(CancellationToken cancellationToken)
        {
            Start?.Invoke();
            YieldAwaitable cachedYieldAwaitable = UniTask.Yield();
            while (!cancellationToken.IsCancellationRequested)
            {
                await cachedYieldAwaitable;
                Tick?.Invoke(Time.deltaTime);
            }
        }

        private void OnDestroy()
        {
            StopTicks();
        }
    }
}