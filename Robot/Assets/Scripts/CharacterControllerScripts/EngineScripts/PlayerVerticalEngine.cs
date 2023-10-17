using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class PlayerVerticalEngine : MonoBehaviour, IEngine
    {
        [Header("Values")]
        [SerializeField] private float thrustForce;

        public void EngineOperation(Rigidbody rb)
        {
            rb.AddForce(rb.transform.up * thrustForce, ForceMode.Impulse);
        }
    }
}

