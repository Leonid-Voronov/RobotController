using UnityEngine;

namespace RobotDemo
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform leftTrackTransform;
        [SerializeField] private Transform rightTrackTransform;

        [Header("Values")]
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float playerHeight;
        [SerializeField] private float groundDrag;
        [SerializeField] private float raycastExtension;
        [SerializeField] private float trackHeight;
        
        private bool grounded;
        private Vector3 hitNormal;
        public bool Grounded => grounded;
        public Vector3 HitNormal => hitNormal;

        private void FixedUpdate()
        {
            /*grounded = Physics.Raycast(transform.position, -rb.transform.up, out RaycastHit slopeHit , playerHeight * .5f + raycastExtension, groundMask);

            if (grounded)
            {
                rb.drag = groundDrag;
                hitNormal = slopeHit.normal;
            }
            else
            {
                rb.drag = 0;
            }*/

            Vector3 lowestNormal = GetLowestNormal();
            grounded = lowestNormal != Vector3.zero;

            if (grounded)
            {
                rb.drag = groundDrag;
                hitNormal = lowestNormal;
            }
            else
            {
                rb.drag = 0;
            }
        }

        public Vector3 GetLowestNormal()
        {
            bool leftTrackGrounded = Physics.Raycast(leftTrackTransform.position, -leftTrackTransform.up, 
                                                     out RaycastHit leftTrackHit, trackHeight * .5f + raycastExtension, groundMask);
            bool rightTrackGrounded = Physics.Raycast(rightTrackTransform.position, -rightTrackTransform.up,
                                                     out RaycastHit rightTrackHit, trackHeight * .5f + raycastExtension, groundMask);

            if (!leftTrackGrounded && !rightTrackGrounded)
                return Vector3.zero;

            if (!leftTrackGrounded)
                return rightTrackHit.normal;

            if(!rightTrackGrounded)
                return leftTrackHit.normal;

            return (leftTrackHit.normal + rightTrackHit.normal) * .5f;
        }
    }
}

