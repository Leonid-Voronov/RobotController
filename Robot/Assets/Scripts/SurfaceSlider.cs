using UnityEngine;

namespace RobotDemo
{
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector3 normal;

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.collider.GetComponent<Ground>())
            {
                normal = collision.contacts[0].normal;
            }
        }

        public Vector3 Project(Vector3 forward)
        {
            return forward - Vector3.Dot(forward, normal) * normal;
        }
    }

}

