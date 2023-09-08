using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref LocalTransform transform, in Speed speed, in TargetPosition targetPosition) =>
        {
            //calculate direction
            float3 direction = math.normalize(targetPosition.Value - transform.Position);
            //Move
            transform.Position += direction * (SystemAPI.Time.DeltaTime * speed.Value);
        }).Run();
    }
}
