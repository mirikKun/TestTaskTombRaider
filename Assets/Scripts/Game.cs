using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Transform _destination;
        [SerializeField] private float _timeToStartGame;
        private LevelGenerator _levelGenerator;
        private Player _player;
        private Vector3 _playerStartPosition;
        private Delayer _delayer;
        private LevelRestartAnimator _levelRestartAnimator;

        [Inject]
        private void Construct(Player player, LevelGenerator levelGenerator, Delayer delayer,
            LevelRestartAnimator levelRestartAnimator)
        {
            _player = player;
            _levelGenerator = levelGenerator;
            _delayer = delayer;
            _playerStartPosition = _player.transform.position;
            _levelRestartAnimator = levelRestartAnimator;
        }

        private void Start()
        {
            Restart();
            _delayer.Wait(_timeToStartGame, SetupPlayerDestination);
            _player.OnDeath += () => StartRestartingLevel(false);
            _player.OnDestinationReach += () => StartRestartingLevel(true);
        }

        private void OnDestroy()
        {
            _player.OnDeath -= () => StartRestartingLevel(false);
            _player.OnDestinationReach -= () => StartRestartingLevel(true);
        }

        public void StartRestartingLevel(bool regenerateLevel) => StartCoroutine(LevelRestart(regenerateLevel));

        public void Restart(bool regenerateLevel = true)
        {
            if (regenerateLevel)
            {
                GenerateLevel();
            }

            _player.RestartPlayer(_playerStartPosition);
        }

        private void SetupPlayerDestination()
        {
            Debug.Log(122);
            _player.SetupDestination(_destination.position);
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
        private void GenerateLevel()
        {
            _levelGenerator.ClearLevel();
            _levelGenerator.GenerateLevel();
        }

        private IEnumerator LevelRestart(bool regenerateLevel)
        {
            yield return new WaitForSeconds(2);
            _levelRestartAnimator.StartFadeIn();
            yield return new WaitForSeconds(1);
            Restart(regenerateLevel);
            _levelRestartAnimator.StartFadeOut();
            yield return new WaitForSeconds(3);

            SetupPlayerDestination();
            _player.MovePlayer();
        }
    }
}