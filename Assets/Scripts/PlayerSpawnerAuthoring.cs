using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject playerPrefab;
}


public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{

    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new PlayerSpawner
        {
            playerPrefab = GetEntity(authoring.playerPrefab, TransformUsageFlags.Dynamic),
        });
    }
}