using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game:MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;

        [SerializeField] private Player _player;
        [SerializeField] private Transform _destination;
        private void Start()
        {
            _levelGenerator.GenerateLevel();
            _player.SetupDestination(_destination.position);
        }

        [ContextMenu("Generate")]
        private void RegenerateLevel()
        {
            _levelGenerator.ClearLevel();
            _levelGenerator.GenerateLevel();

        }
    }
}