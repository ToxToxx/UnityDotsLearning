using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<PlayerSpawner>();
    }

    protected override void OnUpdate()
    {
        EntityQuery playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));

        PlayerSpawner playerSpawner = SystemAPI.GetSingleton<PlayerSpawner>();


        int spawnAmount = 2;
        if( playerEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            EntityManager.Instantiate(playerSpawner.playerPrefab);
        }
    }
}
