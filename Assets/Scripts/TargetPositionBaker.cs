using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TargetPositionBaker : Baker<TargetPositionAuthoring>
{

    public override void Bake(TargetPositionAuthoring authoring)
    {
        AddComponent(this.GetEntity(TransformUsageFlags.Dynamic), new TargetPosition
        {
            Value = authoring.Value
        });
    }
}
