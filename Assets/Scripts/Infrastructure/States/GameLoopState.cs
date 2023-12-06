using UnityEngine;

namespace Infrastructure.States
{
  public class GameLoopState : IState
  {
    public GameLoopState(GameStateMachine stateMachine)
    {
      
    }

    public void Enter()
    {
      Debug.Log(1111111);
    }

    public void Exit()
    {
      
    }
  }
}