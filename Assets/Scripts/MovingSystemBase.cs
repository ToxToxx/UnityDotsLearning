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
        float deltaTime = SystemAPI.Time.DeltaTime;

        Entities.ForEach((MoveToPositionAspect moveToPositionAspect) =>
        {
            moveToPositionAspect.Move(deltaTime);
            moveToPositionAspect.TestReachedTargetPosition(randomComponent);
        }).Run();
    }
}
