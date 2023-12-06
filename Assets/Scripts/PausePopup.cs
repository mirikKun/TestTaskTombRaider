using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class PausePopup:MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        private Mediator _mediator;
        

        [Inject]
        private void Construct(Mediator mediator)
        {
            _mediator = mediator;
        }
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
            _mediator.ClosePauseMenu();
            _mediator.ContinueGame();
            Time.timeScale = 1;
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}