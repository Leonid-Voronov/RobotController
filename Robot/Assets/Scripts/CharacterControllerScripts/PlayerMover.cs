using UnityEngine;

namespace RobotDemo
{
    public class PlayerMover : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Input input;
        [SerializeField] private Transform orientationTransform;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerGroundChecker groundChecker;
        [SerializeField] private SurfaceSlider surfaceSlider;
        [SerializeField] private TrackAnimator trackAnimator;
        [SerializeField] private Transform leftTrackTransform;
        [SerializeField] private Transform rightTrackTransform;

        [Header("Values")]
        [SerializeField] private float groundMoveSpeed;
        [SerializeField] private float airMoveSpeed;
        [SerializeField] private float forceModifier;

        private Vector3 moveDirection;

        private void FixedUpdate()
        {
            moveDirection = orientationTransform.forward * input.InputDirection.y;

            float currentSpeed = groundChecker.Grounded ? groundMoveSpeed : airMoveSpeed;
            Vector3 directionAlongSurface = surfaceSlider.Project(moveDirection);

            Vector3 leftWheelForce = directionAlongSurface.normalized * currentSpeed * forceModifier;
            Vector3 rightWheelForce = directionAlongSurface.normalized * currentSpeed * forceModifier;

            rb.AddForceAtPosition(leftWheelForce, leftTrackTransform.position, ForceMode.Force);
            rb.AddForceAtPosition(rightWheelForce, rightTrackTransform.position, ForceMode.Force);

            SpeedControl();

            if (groundChecker.Grounded) 
            {
                float normalizedSpeed = rb.velocity.magnitude * Vector3.Dot(rb.velocity, transform.forward);
                trackAnimator.AnimateTracks(normalizedSpeed, input.InputDirection, groundMoveSpeed);
            }
            else
            {
                trackAnimator.StopAnimation();
            }
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

