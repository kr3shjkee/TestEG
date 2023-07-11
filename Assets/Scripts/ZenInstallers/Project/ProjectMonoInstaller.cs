using Common;
using Signals;
using UnityEngine;
using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        BindSignals();

        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<SaveSystem>().AsSingle().NonLazy();   
    }

    private void BindSignals()
    {
        Container.DeclareSignal<ClosePanelSignal>();
        Container.DeclareSignal<OpenPanelSignal>();
        Container.DeclareSignal<PauseSignal>();
        Container.DeclareSignal<UnpauseSignal>();
        Container.DeclareSignal<StartGameSignal>();
    }
}