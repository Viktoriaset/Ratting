using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Transform playerSpawnPosition;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject ecsGameStartupPrefab;
    public override void InstallBindings()
    {
        BindPlayer();
        BindEcsGameStartup();
    }

    private void BindEcsGameStartup()
    {
        var ecsGameStartup = Container.InstantiatePrefab(ecsGameStartupPrefab);
        Container.Bind<ECSGameStartup>().FromComponentInNewPrefab(ecsGameStartup).AsSingle();
    }


    private void BindPlayer()
    {
        var player = Container.InstantiatePrefab(playerPrefab, playerSpawnPosition.position, Quaternion.identity, null);
    }

}