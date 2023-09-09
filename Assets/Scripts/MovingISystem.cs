using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections.LowLevel.Unsafe;

public partial struct MovingISystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

        state.RequireForUpdate<RandomComponent>();
    }

    public void OnUpdate(ref SystemState state)
    {
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        float deltaTime = SystemAPI.Time.DeltaTime;

        JobHandle jobHandle = new MoveJob
        {
            deltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);

        jobHandle.Complete();

        new TestReachedTargetPositionJob
        {
            randomComponent = randomComponent
        }.Run();
    }
}

public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(deltaTime);
    }
}
public partial struct TestReachedTargetPositionJob : IJobEntity
{
   [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> randomComponent;
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(randomComponent);
    }
}