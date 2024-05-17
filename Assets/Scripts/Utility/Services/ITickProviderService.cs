using System;

namespace SpaceInvaders.Utility.Services
{
    public interface ITickProviderService
    {
        event Action<float> Tick;
    }
}