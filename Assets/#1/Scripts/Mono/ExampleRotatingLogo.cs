using UnityEngine;

namespace Lesson1
{
    public class ExampleRotatingLogo : MonoBehaviour
    {
        public float speed = 35f;

        private void Update()
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}