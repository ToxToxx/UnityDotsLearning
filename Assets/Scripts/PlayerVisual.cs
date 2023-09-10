using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Entity _entity;


    private Entity GetRandomEntity()
    {
        EntityQuery playerTagEntityQuery =  World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTag));
        NativeArray <Entity> entityNativeArray = playerTagEntityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        if(entityNativeArray.Length > 0)
        {
            return entityNativeArray[Random.Range(0, entityNativeArray.Length)];
        }
        else
        {
            return Entity.Null;
        }
    }

}
