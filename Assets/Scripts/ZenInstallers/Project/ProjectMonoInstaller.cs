using Common;
using Signals;
using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        BindSignals();

        Container.Bind<SaveSystem>().AsSingle().NonLazy();   
    }

    private void BindSignals()
    {
        Container.DeclareSignal<ClosePanelSignal>();
        Container.DeclareSignal<OpenPanelSignal>();
        Container.DeclareSignal<PauseSignal>();
        Container.DeclareSignal<UnpauseSignal>();
        Container.DeclareSignal<StartGameSignal>();
        Container.DeclareSignal<LoseGameSignal>();
        Container.DeclareSignal<ScoreChangedSignal>(); 
    }
}