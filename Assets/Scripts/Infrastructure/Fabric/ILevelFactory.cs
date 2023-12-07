using UnityEngine;

namespace Infrastructure.Fabric
{
    public interface ILevelFactory
    {
        Transform CreateWall(Vector3 at, Vector3 scale, Transform parent);
        Transform CreateDeathZone(Vector3 at, Transform parent);
    }
}