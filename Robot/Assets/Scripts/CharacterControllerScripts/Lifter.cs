using UnityEngine;

namespace RobotDemo
{
    public class Lifter : MonoBehaviour
    {
        [SerializeField] private float liftForce;
        public void LiftRB(Rigidbody rb)
        {
            rb.AddForce(rb.transform.up * liftForce, ForceMode.Impulse);
        }
    }
}

