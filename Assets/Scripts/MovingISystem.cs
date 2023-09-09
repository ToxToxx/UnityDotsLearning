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

        float deltaTime = SystemAPI.Time.DeltaTime;
        new MoveJob
        {
            deltaTime = deltaTime
        }.ScheduleParallel();

        return;
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
    public RefRW<RandomComponent> randomComponent;
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(randomComponent);
    }
}