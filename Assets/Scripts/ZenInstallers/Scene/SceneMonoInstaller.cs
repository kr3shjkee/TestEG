using Game;
using UnityEngine;
using Zenject;

public class SceneMonoInstaller : MonoInstaller
{
    [SerializeField] private UiController uiControllerPrefab;
    [SerializeField] private LevelPart levelPartPrefab;
    [SerializeField] private LevelController levelControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<UiController>().FromComponentInNewPrefab(uiControllerPrefab).AsSingle().NonLazy();
        Container.Bind<LevelController>().FromComponentInNewPrefab(levelControllerPrefab).AsSingle().NonLazy();
        Container.BindFactory<DamagePosition, BonusItemPosition, LevelPart, LevelPart.Factory>().FromComponentInNewPrefab(levelPartPrefab);
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
    }
}