using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Lesson4
{
    public class InstantiateEntitiesSystem : SystemBase
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
                .ForEach((ref InstantiateEntityData instantiateData) =>
                {
                    if(instantiateData.nextRespawnTime > currentTime)
                    {
                        return;
                    }

                    instantiateData.nextRespawnTime = currentTime + (instantiateData.respawnIntervalInMiliseconds / 1000);

                    var newEntity = ecb.Instantiate(instantiateData.prefabToInstantiate);

                    ecb.SetComponent<Translation>(newEntity, new Translation
                    {
                        Value = float3.zero
                    });

                    ecb.AddComponent<LifeTimeData>(newEntity, new LifeTimeData
                    {
                        lifeTime = (instantiateData.entityLifeTimeInMiliseconds / 1000) + currentTime
                    });

                }).Schedule();

            endSimulationBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}