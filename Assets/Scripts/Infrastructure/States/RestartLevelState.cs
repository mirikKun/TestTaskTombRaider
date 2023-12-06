using Infrastructure.Logic;

namespace Infrastructure.States
{
    public class RestartLevelState:IState
    {
        private const string MainLevel = InfrastructureAssetPath.MainScene;
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public RestartLevelState(GameStateMachine stateMachine, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _curtain = curtain;
        }

        public void Enter()
        {
            _curtain.Show();
            _sceneLoader.Load(MainLevel, OnLoaded);
        }

        public void Exit()
        {
            _curtain.StartHiding();
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}