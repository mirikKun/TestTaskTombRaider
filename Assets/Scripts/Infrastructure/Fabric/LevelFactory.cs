using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure.Fabric
{
    public class LevelFactory : ILevelFactory
    {
        private readonly IAssetProvider _assets;
        private GameObject _playerGameObject;

        private Transform _wallAsset;
        private Transform _deathZoneAsset;

        [Inject]
        public LevelFactory(IAssetProvider assets)
        {
            _assets = assets;
            WarmUpData();
        }

        private void WarmUpData()
        {
            _wallAsset = _assets.GetAsset(path: InfrastructureAssetPath.Wall).transform;
            _deathZoneAsset = _assets.GetAsset(path: InfrastructureAssetPath.DeathZone).transform;
        }

        public Transform CreateWall(Vector3 at, Vector3 scale, Transform parent)
        {
            Transform wall = Object.Instantiate(_wallAsset, at, Quaternion.identity, parent);
            wall.localScale = scale;
            return wall;
        }

        public Transform CreateDeathZone(Vector3 at, Transform parent)
        {
            Transform deathZone=Object.Instantiate(_deathZoneAsset.transform, at, Quaternion.identity, parent);
            return deathZone;
        }
    }
}