using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Lesson4
{
    public class LifeTimeSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem endSimulationBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();
            endSimulationBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            float currentTime = UnityEngine.Time.realtimeSinceStartup;
            var ecb = endSimulationBufferSystem.CreateCommandBuffer();

            Entities
                .ForEach((in Entity entity, in LifeTimeData lifeTimeData) =>
                {
                    if(lifeTimeData.lifeTime > currentTime)
                    {
                        return;
                    }

                    ecb.DestroyEntity(entity);
                }).Schedule();

            endSimulationBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}
