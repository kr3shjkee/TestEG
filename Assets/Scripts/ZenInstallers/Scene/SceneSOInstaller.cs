using ScriptableObjects;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SceneSOInstaller", menuName = "Installers/SceneSOInstaller")]
public class SceneSOInstaller : ScriptableObjectInstaller<SceneSOInstaller>
{
    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private BonusItemsConfig bonusItemsConfig;
    public override void InstallBindings()
    {
        Container.BindInstances(levelConfig, bonusItemsConfig);
    }
}