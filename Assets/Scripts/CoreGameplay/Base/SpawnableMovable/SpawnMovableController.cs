using Cysharp.Threading.Tasks;
using SpaceInvaders.AssetsSpawn;
using SpaceInvaders.CoreGameplay.Base.Spawnable;
using SpaceInvaders.CoreGameplay.Base.SpawnFeature;

namespace SpaceInvaders.CoreGameplay.Base.SpawnableMovable
{
    public class SpawnMovableController : SpawnController
    {
        public SpawnMovableController(SpawnView spawnView, SpawnModel spawnModel, IAssetsSpawnService assetsSpawnService, SpawnablePresenterFactory spawnablePresenterFactory) : base(spawnView, spawnModel, assetsSpawnService, spawnablePresenterFactory)
        {
        }

        protected override async UniTask<SpawnableView> SpawnViewInternal(SpawnableModel spawnableModel)
        {
            SpawnableView spawnableView = await base.SpawnViewInternal(spawnableModel);
            SpawnableMovableModel spawnableMovableModel = (SpawnableMovableModel)spawnableModel;
            spawnableView.Transform.localPosition = spawnableMovableModel.MovableModel.Position;
            spawnableView.Transform.forward = spawnableMovableModel.MovableModel.DirectionNormalized;
            return spawnableView;
        }
    }
}