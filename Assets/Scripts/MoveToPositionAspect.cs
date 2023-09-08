using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial  struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;

    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;


    public void Move(float deltaTime)
    {
        //calculate direction
        float3 direction = math.normalize(_targetPosition.ValueRW.Value - _transform.ValueRW.Position);
        //Move to target position
        _transform.ValueRW.Position += direction * deltaTime * _speed.ValueRO.Value;

        float reachedTargetDistance = .5f;
        if (math.distancesq(_transform.ValueRW.Position, _targetPosition.ValueRW.Value) < reachedTargetDistance)
        {
            //Generate New Random Target Position
        }
    }
}
