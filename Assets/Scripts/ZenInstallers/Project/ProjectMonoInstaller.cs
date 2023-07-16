using Common;
using Signals;
using UnityEngine;
using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    [SerializeField] private AudioController audioControllerPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        BindSignals();

        Container.Bind<SaveSystem>().AsSingle().NonLazy();
        Container.Bind<AudioController>().FromComponentInNewPrefab(audioControllerPrefab).AsSingle().NonLazy();
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
        Container.DeclareSignal<FinishTriggerSignal>();
        Container.DeclareSignal<PushSoundSignal>();
        Container.DeclareSignal<OptionChangedSignal>();
    }
}