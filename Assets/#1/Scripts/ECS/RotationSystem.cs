using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Lesson1
{
    public class RotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float delta = Time.DeltaTime;

            Entities
                .ForEach((ref Rotation rotation, in RotationData rotationData) =>
                {
                    rotation.Value = math.mul(rotation.Value, quaternion.RotateY(math.radians(rotationData.speed * delta)));
                }).Schedule();

        }
    }
}