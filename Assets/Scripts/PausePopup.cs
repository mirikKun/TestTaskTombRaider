using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PausePopup:MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private UIMediator _uiMediator;

        private void Start()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            _continueButton.onClick.AddListener(ContinueGame);        
            _exitButton.onClick.AddListener(Exit);        
        }

        private void ContinueGame()
        {
            _uiMediator.ClosePauseMenu();
            Time.timeScale = 1;
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}