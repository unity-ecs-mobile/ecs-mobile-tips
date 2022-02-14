using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Lesson4
{
    public class MoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities
                .ForEach((ref Translation translation, in LocalToWorld localToWorld, in MoveData moveData) =>
                {
                    translation.Value = translation.Value + localToWorld.Right * (deltaTime * moveData.speed);
                }).Schedule();
        }
    }
}