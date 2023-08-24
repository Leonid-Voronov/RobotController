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

        [Header("Values")]
        [SerializeField] private float groundMoveSpeed;
        [SerializeField] private float airMoveSpeed;
        [SerializeField] private float forceModifier;

        private Vector3 moveDirection;

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            moveDirection = orientationTransform.forward * input.InputDirection.y + orientationTransform.right * input.InputDirection.x;
            float currentSpeed = groundChecker.Grounded ? groundMoveSpeed : airMoveSpeed;
            Vector3 directionAlongSurface = surfaceSlider.Project(moveDirection);
            rb.MovePosition(rb.position +  directionAlongSurface * currentSpeed * Time.fixedDeltaTime);
            //rb.AddForce(directionAlongSurface.normalized * currentSpeed * forceModifier, ForceMode.Force);
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

