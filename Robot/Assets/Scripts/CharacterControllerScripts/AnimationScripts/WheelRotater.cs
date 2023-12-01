using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class WheelRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private List<Transform> leftWheelTransforms = new List<Transform>();
        [SerializeField] private List<Transform> rightWheelTransforms = new List<Transform>();

        [Header("Values")]
        [SerializeField] private float angularSpeed;


        public void AnimateWheels(float leftSpeed, float rightSpeed)
        {
            foreach (Transform leftWheelTransform in leftWheelTransforms)
            {
                leftWheelTransform.Rotate(new Vector3(0f, 1f, 0f), angularSpeed * leftSpeed * Time.fixedDeltaTime);
            }

            foreach (Transform rightWheelTransform in rightWheelTransforms)
            {
                rightWheelTransform.Rotate(new Vector3(0f, 1f, 0f), angularSpeed * rightSpeed * Time.fixedDeltaTime);
            }
        }
    }
}

