using SpaceInvaders.CoreGameplay.Base.SpawnableMovable;
using SpaceInvaders.CoreGameplay.Base.SpawnFeature;
using Zenject;

namespace SpaceInvaders.Player
{
    public class PlayerService : IInitializable
    {
        private readonly SpawnMovableService _spawnMovableService;
        private readonly SpawnableCollectionConfig<SpawnableMovableData> _collectionConfig;
        private readonly PlayerConfig _playerConfig;

        public PlayerService(SpawnMovableService spawnMovableService, SpawnableMovableCollectionConfig collectionConfig, PlayerConfig playerConfig)
        {
            _spawnMovableService = spawnMovableService;
            _collectionConfig = collectionConfig;
            _playerConfig = playerConfig;
        }

        public void Initialize()
        {
            _spawnMovableService.Spawn(_playerConfig.PlayerSpawnID);
        }
    }
}