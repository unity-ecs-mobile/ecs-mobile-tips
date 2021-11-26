using UnityEngine;
using Unity.Entities;

namespace Lesson1
{

    public class MonoRotationConvert : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var monoSpeedObject = gameObject.GetComponent<ExampleRotatingLogo>();

            if(null == monoSpeedObject)
            {
                return;
            }

            dstManager.AddComponentData<RotationData>(entity, new RotationData
            {
                speed = monoSpeedObject.speed
            });
        }
    }
}