using UnityEngine;
using Zenject;

public class SceneMonoInstaller : MonoInstaller
{
    [SerializeField] private UiController uiControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<UiController>().FromComponentInNewPrefab(uiControllerPrefab).AsSingle().NonLazy();
    }
}