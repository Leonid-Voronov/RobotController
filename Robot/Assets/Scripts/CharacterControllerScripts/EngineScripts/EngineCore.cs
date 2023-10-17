using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class EngineCore : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerVerticalEngine playerVerticalEngine;
        [SerializeField] private PlayerHorizontalEngine playerHorizontalEngine;

        [Header("Values")]
        [SerializeField] private float maxVelocity;

        private List<IEngine> engineModes = new List<IEngine>();
        private int currentEngineModeIndex = 0;

        private bool flyInput;
        public bool FlyInput => flyInput;

        private void Awake()
        {
            engineModes.Add(playerVerticalEngine);
            engineModes.Add(playerHorizontalEngine);
        }

        private void Update()
        {
            if (flyInput)
            {
                engineModes[currentEngineModeIndex].EngineOperation(rb);
            }

            SpeedControl();
        }

        public void ChangeEngineMode()
        {

            currentEngineModeIndex++;

            if (currentEngineModeIndex >= engineModes.Count)
                currentEngineModeIndex = 0;
        }

        public void InputResponse()
        {
            if (engineModes.Count == 0 || currentEngineModeIndex >= engineModes.Count)
                return;

            flyInput = !flyInput;
        }

        public void SpeedControl()
        {
            if (rb.velocity.y > maxVelocity)
                rb.velocity = new Vector3(rb.velocity.x, maxVelocity, rb.velocity.z);
        }
    }
}

