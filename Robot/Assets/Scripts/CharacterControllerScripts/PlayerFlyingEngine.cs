using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class PlayerFlyingEngine : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;

        [Header("Values")]
        [SerializeField] private float thrustForce;
        [SerializeField] private float maxVelocity;

        private bool flyInput;
        public bool FlyInput => flyInput;

        private void Update()
        {
            if(flyInput) 
            {
                rb.AddForce(rb.transform.up * thrustForce, ForceMode.Impulse);
            }

            SpeedControl();
        }

        private void SpeedControl()
        {
            if (rb.velocity.y > maxVelocity)
                rb.velocity = new Vector3 (rb.velocity.x, maxVelocity, rb.velocity.z);
        }

        public void ToggleFlyInput()
        {
            flyInput = !flyInput;
        }
    }
}

