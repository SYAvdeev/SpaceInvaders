using System;
using SpaceInvaders.Utility.Services.Input;
using UnityEngine;

namespace SpaceInvaders.Utility.Services
{
    public class InputService : MonoBehaviour, IInputService
    {
        [SerializeField] private KeyCode _moveKey;
        [SerializeField] private KeyCode _rotateRightKey;
        [SerializeField] private KeyCode _rotateLeftKey;
        [SerializeField] private KeyCode _shootKey;
        [SerializeField] private KeyCode _nextItemKey;
        [SerializeField] private KeyCode _previousItemKey;
        [SerializeField] private KeyCode _pauseKey;
        
        public event Action<InputType> OnInput;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(_moveKey))
            {
                OnInput?.Invoke(InputType.StartMove);
            }
            else if (UnityEngine.Input.GetKeyUp(_moveKey))
            {
                OnInput?.Invoke(InputType.StopMove);
            }

            if (UnityEngine.Input.GetKeyDown(_rotateRightKey))
            {
                OnInput?.Invoke(InputType.StartTurnRight);
            }
            else if (UnityEngine.Input.GetKeyUp(_rotateRightKey))
            {
                OnInput?.Invoke(InputType.StopTurnRight);
            }
            else if (UnityEngine.Input.GetKeyDown(_rotateLeftKey))
            {
                OnInput?.Invoke(InputType.StartTurnLeft);
            }
            else if (UnityEngine.Input.GetKeyUp(_rotateLeftKey))
            {
                OnInput?.Invoke(InputType.StopTurnLeft);
            }

            if (UnityEngine.Input.GetKey(_shootKey))
            {
                OnInput?.Invoke(InputType.Shoot);
            }
            
            if (UnityEngine.Input.GetKeyDown(_nextItemKey))
            {
                OnInput?.Invoke(InputType.NextItem);
            }
            
            if (UnityEngine.Input.GetKeyDown(_previousItemKey))
            {
                OnInput?.Invoke(InputType.PreviousItem);
            }
        }
    }
}