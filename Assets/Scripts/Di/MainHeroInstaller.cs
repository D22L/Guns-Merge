using UnityEngine;
using Zenject;
using GunsMerge;

public class MainHeroInstaller : MonoInstaller
{
    [SerializeField] private Transform _heroStartPoint;
    [SerializeField] private MainHero _mainHeroPFB;
    public override void InstallBindings()
    {
        Container.Bind<MainHero>().FromMethod(SpawnHero).AsSingle().NonLazy();
    }

    private MainHero SpawnHero()
    {
        var hero = Instantiate(_mainHeroPFB);
        hero.transform.position = _heroStartPoint.position;
        return hero;
    }
}