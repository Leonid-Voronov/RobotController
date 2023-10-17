using UnityEngine;

namespace RobotDemo
{
    public class PlayerHorizontalEngine : MonoBehaviour, IEngine
    {
        [SerializeField] private Lifter lifter;
        private const float thrustForce = 15f;
        public void EngineOperation(Rigidbody rb)
        {
            rb.AddForce(rb.transform.forward * thrustForce, ForceMode.Impulse);
            lifter.LiftRB(rb);
        }


    }
}

