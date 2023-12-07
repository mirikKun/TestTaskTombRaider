using DefaultNamespace;
using Infrastructure.AssetManagement;

using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private Game _game;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private PopupAnimator _popupAnimator;
        [SerializeField] private LevelRestartAnimator _levelRestartAnimator;
        [SerializeField] private Mediator _mediator;

        [SerializeField] private Transform _spawnPoint;
        private IAssetProvider _assets;

        [Inject]
        private void Construct(IAssetProvider assets)
        {
            _assets = assets;
        }

        public override void InstallBindings()
        {                      
            BindLevelRestartAnimator();
            BindPopupAnimator();

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
            Player player = Container.InstantiatePrefabForComponent<Player>(_assets.GetAsset(path: InfrastructureAssetPath.Player),_spawnPoint.position,Quaternion.identity,_spawnPoint);
            Container
                .Bind<Player>()
                .FromInstance(player);
        }

        private void BindMediator()
        {
            Container
                .Bind<Mediator>()
                .FromInstance(_mediator)
                .AsSingle();
        }
        private void BindLevelRestartAnimator()
        {
            Container
                .Bind<LevelRestartAnimator>()
                .FromInstance(_levelRestartAnimator)
                .AsSingle();
        }
        private void BindPopupAnimator()
        {
            Container
                .Bind<PopupAnimator>()
                .FromInstance(_popupAnimator)
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