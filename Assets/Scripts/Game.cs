using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Game:MonoBehaviour
    {
        [SerializeField] private Transform _destination;
        private LevelGenerator _levelGenerator;
        private Player _player;
        private Vector3 _playerStartPosition;

        [Inject]
        private void Construct(Player player,LevelGenerator levelGenerator)
        {
            _player = player;
            _levelGenerator = levelGenerator;
            _playerStartPosition = _player.transform.position;
        }
        private void Start()
        {
            _levelGenerator.GenerateLevel();
            _player.SetupDestination(_destination.position);
        }

        public void Restart(bool regenerateLevel)
        {
            if (regenerateLevel)
            {
                _levelGenerator.ClearLevel();
                _levelGenerator.GenerateLevel();
            }
            _player.RestartPlayer(_playerStartPosition);
        }
        public void PauseGame()
        {
            _player.StopPlayer();
            
        }

        public void ContinueGame()
        {
            _player.MovePlayer();

        }

        [ContextMenu("Generate")]
        private void RegenerateLevel()
        {
            _levelGenerator.ClearLevel();
            _levelGenerator.GenerateLevel();

        }
    }
}