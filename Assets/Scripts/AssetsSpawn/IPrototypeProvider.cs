using Cysharp.Threading.Tasks;

namespace SpaceInvaders.AssetsSpawn
{
    public interface IPrototypeProvider
    {
        UniTask<T> Get<T>(string key);
        void Release(string key);
    }
}