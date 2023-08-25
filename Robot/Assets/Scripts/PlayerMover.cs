using UnityEditor.Timeline;
using UnityEngine;

namespace TPD
{
    public class PlayerMover : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Input input;
        [SerializeField] private Transform orientationTransform;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerGroundChecker groundChecker;
        [SerializeField] private SurfaceSlider surfaceSlider;
        [SerializeField] private Transform leftTrackTransform;
        [SerializeField] private Transform rightTrackTransform;

        [Header("Values")]
        [SerializeField] private float groundMoveSpeed;
        [SerializeField] private float airMoveSpeed;
        [SerializeField] private float forceModifier;

        private Vector3 moveDirection;
        private float leftTrackForceModifier;
        private float rightTrackForceModifier;

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            leftTrackForceModifier = 1f;
            rightTrackForceModifier = 1f;

            moveDirection = orientationTransform.forward * input.InputDirection.y;

            /*if (input.InputDirection.x < 0)
            {
                leftTrackForceModifier = 0.5f;
            }
            else if (input.InputDirection.x > 0)
            {
                rightTrackForceModifier = 0.5f;
            }*/

            float currentSpeed = groundChecker.Grounded ? groundMoveSpeed : airMoveSpeed;
            Vector3 directionAlongSurface = surfaceSlider.Project(moveDirection);

            //rb.AddForce(directionAlongSurface.normalized * currentSpeed * forceModifier, ForceMode.Force);
            Vector3 leftWheelForce = directionAlongSurface.normalized * currentSpeed * forceModifier * leftTrackForceModifier;
            Vector3 rightWheelForce = directionAlongSurface.normalized * currentSpeed * forceModifier * rightTrackForceModifier;

            rb.AddForceAtPosition(leftWheelForce, leftTrackTransform.position, ForceMode.Force);
            rb.AddForceAtPosition(rightWheelForce, rightTrackTransform.position, ForceMode.Force);

            SpeedControl();

        }

        private void SpeedControl()
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVelocity.magnitude > groundMoveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * groundMoveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
        }
    }
}

