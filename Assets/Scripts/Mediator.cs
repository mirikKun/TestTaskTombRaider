using DefaultNamespace;
using Infrastructure.States;
using UnityEngine;
using Zenject;

public class Mediator : MonoBehaviour
{
     private PopupAnimator _popupAnimator;
     private GameStateMachine _stateMachine;
     private Game _game;
     [Inject]
     private void Construct(PopupAnimator popupAnimator,GameStateMachine stateMachine,Game game)
     {
         _popupAnimator = popupAnimator;
         _stateMachine = stateMachine;
         _game = game;
     }
    public void OpenPauseMenu() => _popupAnimator.StartAnimationIn();
    public void PauseGame() => _game.PauseGame();
    public void Restart() => _game.Restart();

    public void ClosePauseMenu() => _popupAnimator.StartAnimationOut();
    public void ContinueGame() => _game.ContinueGame();

}
