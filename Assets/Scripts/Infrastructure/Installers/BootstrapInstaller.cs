using Infrastructure.AssetManagement;
using Infrastructure.Fabric;
using Infrastructure.Logic;
using Infrastructure.Services.Input;
using Infrastructure.States;
using UnityEngine;
using Zenject;
using AndroidInput = Infrastructure.Services.Input.AndroidInput;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindSceneLoader();
            BindCurtain();

            BindInputService();
            BindAssetProvider();
       

            BindFactory();
            BindStateMachine();
            BindAssetDelayer();
        }

        private void BindFactory()
        {
            Container
                .Bind<ILevelFactory>()
                .To<LevelFactory>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>().To<AssetProvider>()
                .AsSingle();
        }
        private void BindAssetDelayer()
        {
            Container
                .Bind<Delayer>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle();

        }


        private void BindInputService()
        {
            Container.Bind<IInput>().To<AndroidInput>().AsSingle();
        }

        private void BindCurtain()
        {
            LoadingCurtain loadingCurtain = Container
                .InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);
            Container
                .Bind<LoadingCurtain>()
                .FromInstance(loadingCurtain)
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }


        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();
        }
    }
}