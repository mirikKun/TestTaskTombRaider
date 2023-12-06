using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Infrastructure.States;
using UnityEngine;
using Zenject;

public class Mediator : MonoBehaviour
{
     private PopupAnimation _popupAnimation;
     private GameStateMachine _stateMachine;
     private Game _game;
     [Inject]
     private void Construct(PopupAnimation popupAnimation,GameStateMachine stateMachine,Game game)
     {
         _popupAnimation = popupAnimation;
         _stateMachine = stateMachine;
         _game = game;
     }
    public void OpenPauseMenu() => _popupAnimation.StartAnimationIn();
    public void PauseGame() => _game.PauseGame();

    public void ClosePauseMenu() => _popupAnimation.StartAnimationOut();
    public void ContinueGame() => _game.ContinueGame();

}
