using Unity.Entities;

namespace Lesson1
{

    [GenerateAuthoringComponent]
    public struct RotationData : IComponentData
    {
        public float speed;
    }
}