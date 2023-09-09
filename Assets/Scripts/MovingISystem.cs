using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial struct MovingISystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

        state.RequireForUpdate<RandomComponent>();
    }

    public void OnUpdate(ref SystemState systemState)
    {
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, randomComponent);
        }
    }
}
