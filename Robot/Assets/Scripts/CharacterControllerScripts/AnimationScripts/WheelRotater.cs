using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{
    public class WheelRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private List<Transform> wheelTransforms = new List<Transform>();

        [Header("Values")]
        [SerializeField] private float angularSpeed;


        /*private void FixedUpdate()
        {
            foreach (Transform wheelTransform in wheelTransforms)
            {
                wheelTransform.Rotate(new Vector3(0f, 0f, 1f), angularSpeed * Time.fixedDeltaTime);
            }
        }*/
    }
}

