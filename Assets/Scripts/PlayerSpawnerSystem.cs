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
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();



        EntityCommandBuffer entityCommandBuffer = 
            SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        int spawnAmount = 10000;
        if( playerEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(playerSpawner.playerPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new Speed
            {
                Value = randomComponent.ValueRW.random.NextFloat(1f, 10f)
            });
        }
    }
}
