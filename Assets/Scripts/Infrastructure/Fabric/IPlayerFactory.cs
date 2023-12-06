using UnityEngine;

namespace Infrastructure.Fabric
{
    public interface IPlayerFactory
    {
        public GameObject CreatePlayer(Transform at);
    }
}