namespace SpaceInvaders.Utility.Services
{
    public interface IPoolService<TKey, TValue>
    {
        bool TryGet(TKey key, out TValue value);
        void Add(TKey key, TValue value);
    }
}