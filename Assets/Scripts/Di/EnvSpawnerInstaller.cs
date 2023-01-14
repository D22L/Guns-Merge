using UnityEngine;
using Zenject;
using GunsMerge;

public class EnvSpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnvironmentSpawner _environmentSpawner;
    public override void InstallBindings()
    {
        Container.Bind<EnvironmentSpawner>().FromInstance(_environmentSpawner).AsSingle().NonLazy();
    }
}