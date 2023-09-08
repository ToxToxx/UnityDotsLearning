using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<RandomComponent>();
    }

    protected override void OnUpdate()
    {
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        Entities.ForEach((MoveToPositionAspect moveToPositionAspect) =>
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, randomComponent);
        }).Run();
    }
}
