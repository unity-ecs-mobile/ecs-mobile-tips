using Unity.Entities;

namespace Lesson4
{
    [GenerateAuthoringComponent]
    public struct InstantiateEntityData : IComponentData
    {
        public Entity prefabToInstantiate;
        public float respawnIntervalInMiliseconds;
        public float nextRespawnTime;
        public float entityLifeTimeInMiliseconds;
    }
}