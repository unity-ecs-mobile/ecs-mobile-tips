using Unity.Entities;

namespace Lesson4
{
    [GenerateAuthoringComponent]
    public struct MoveData : IComponentData
    {
        public float speed;
    }
}