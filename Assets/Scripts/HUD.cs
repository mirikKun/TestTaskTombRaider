using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _shieldButton;
    [SerializeField] private UIMediator _uiMediator;


    private void Start()
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        _uiMediator.OpenPauseMenu();
        //Time.timeScale = 0;
    }
}
