using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Entity _targetEntity;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _targetEntity = GetRandomEntity();
        }
        if (_targetEntity != Entity.Null)
        {
            Vector3 followPosition = 
                World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(_targetEntity).Position;
            transform.position = followPosition;
        }
    }

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
