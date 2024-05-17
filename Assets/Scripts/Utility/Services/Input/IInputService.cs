using System;

namespace SpaceInvaders.Utility.Services.Input
{
    public interface IInputService
    {
        event Action<InputType> OnInput;
    }
}