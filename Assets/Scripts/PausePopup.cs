using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class PausePopup : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restart;
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
            _restart.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            _mediator.ContinueGame();
            _mediator.ClosePauseMenu();

            _mediator.Restart();
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