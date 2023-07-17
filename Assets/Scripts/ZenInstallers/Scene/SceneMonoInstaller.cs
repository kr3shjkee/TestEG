using AbstractClasses;
using Game;
using UnityEngine;
using Zenject;

public class SceneMonoInstaller : MonoInstaller
{
    [SerializeField] private UiController uiControllerPrefab;
    [SerializeField] private LevelPart levelPartPrefab;
    [SerializeField] private StartPart startPartPrefab;
    [SerializeField] private LevelController levelControllerPrefab;
    [SerializeField] private PlayerController playerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<UiController>().FromComponentInNewPrefab(uiControllerPrefab).AsSingle().NonLazy();
        Container.Bind<LevelController>().FromComponentInNewPrefab(levelControllerPrefab).AsSingle().NonLazy();
        Container.BindFactory<DamagePosition, BonusItemPosition, PartPosition, BasePart, BasePart.LevelPartFactory>().FromComponentInNewPrefab(levelPartPrefab);
        Container.BindFactory<PartPosition, BasePart, BasePart.StartPartFactory>().FromComponentInNewPrefab(startPartPrefab);
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<PlayerController>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
    }
}