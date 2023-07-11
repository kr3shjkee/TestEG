using Common;
using UnityEngine;
using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<SaveSystem>().AsSingle().NonLazy();
    }
}