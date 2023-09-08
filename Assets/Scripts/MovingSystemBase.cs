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
        Entities.ForEach((MoveToPositionAspect moveToPositionAspect) =>
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
        }).Run();
    }
}
