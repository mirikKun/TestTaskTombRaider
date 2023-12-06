using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Game:MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private Transform _destination;
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }
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