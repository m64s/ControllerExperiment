﻿using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Collections;

namespace ControllerExperiment
{
    // identify cubes
    public struct CubeTag : IComponentData { }

    public class RotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            // references are not allowed in a job
            // https://docs.unity3d.com/Manual/JobSystemSafetySystem.html
            float deltaTime = Time.DeltaTime;

            // specify entities with cubetag, not all entities
            Entities.WithAll<CubeTag>().ForEach((ref Rotation rotation) =>
            {
                quaternion yRot = quaternion.RotateY(180f * Mathf.Deg2Rad * deltaTime);
                rotation.Value = math.mul(rotation.Value, yRot);
            }).Schedule();
        }
    }

    // single thread
    //public class RotationSystem: ComponentSystem
    //{
    //    protected override void OnUpdate()
    //    {
    //        Entities.ForEach((ref Rotation rotation) =>
    //        {
    //            quaternion yRot = quaternion.RotateY(180f * Mathf.Deg2Rad * Time.DeltaTime);
    //            rotation.Value = math.mul(rotation.Value, yRot);
    //        });
    //    }
    //}
}