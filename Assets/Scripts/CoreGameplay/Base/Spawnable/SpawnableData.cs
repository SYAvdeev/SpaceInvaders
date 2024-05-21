using System;

namespace SpaceInvaders.CoreGameplay.Base.Spawnable
{
    [Serializable]
    public class SpawnableData : ICloneable
    {
        public string ID;
        public object Clone() => MemberwiseClone();
    }
}