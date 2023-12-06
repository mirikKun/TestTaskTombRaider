using DefaultNamespace;
using Infrastructure.Fabric;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private Game _game;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private UIMediator _mediator;

        [SerializeField] private Transform _spawnPoint;
        private IPlayerFactory _playerFactory;

        [Inject]
        private void Construct(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public override void InstallBindings()
        {
            BindPlayer();
            BindLevelGenerator();
            BindGame();
            BindMediator();
        }

        private void BindGame()
        {
            Container
                .Bind<Game>()
                .FromInstance(_game)
                .AsSingle();
        }

        private void BindPlayer()
        {
            GameObject car = _playerFactory.CreatePlayer(_spawnPoint);
            Player carMover = car.GetComponent<Player>();
            Container
                .Bind<Player>()
                .FromInstance(carMover);
        }

        private void BindMediator()
        {
            Container
                .Bind<UIMediator>()
                .FromInstance(_mediator)
                .AsSingle();
        }

        private void BindLevelGenerator()
        {
            Container
                .Bind<LevelGenerator>()
                .FromInstance(_levelGenerator)
                .AsSingle();
        }
    }
}