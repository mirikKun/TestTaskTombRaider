using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HUD : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private ShieldButton _shieldButton;
    private Mediator _mediator;
    private Player _player;

    [Inject]
    private void Construct(Mediator mediator, Player player)
    {
        _mediator = mediator;
        _player = player;
    }

    private void Start()
    {
        _pauseButton.onClick.AddListener(Pause);
        _shieldButton.OnButtonUp += _player.DisableShield;
        _shieldButton.OnButtonDown += _player.EnableShield;
    }

    private void OnDestroy()
    {
        _shieldButton.OnButtonUp -= _player.DisableShield;
        _shieldButton.OnButtonDown -= _player.EnableShield;
    }


    private void Pause()
    {
        _mediator.OpenPauseMenu();
        _mediator.PauseGame();
    }
}