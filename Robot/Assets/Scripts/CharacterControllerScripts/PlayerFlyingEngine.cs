using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class PlayerFlyingEngine : MonoBehaviour
    {
        [SerializeField] private float thrustForce;
        private bool flyInput;

        private void Update()
        {
            if(flyInput) 
            {
                Debug.Log("fly");
            }
        }

        public void ToggleFlyInput()
        {
            flyInput = !flyInput;
        }
    }
}

