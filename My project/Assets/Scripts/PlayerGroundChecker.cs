using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPD
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;

        [Header("Values")]
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float playerHeight;
        [SerializeField] private float groundDrag;
        [SerializeField] private float raycastExtension;
        [SerializeField] private float maxSlopeAngle;
        
        private bool grounded;
        private bool onSlope;
        private Vector3 slopeHitNormal;
        public bool Grounded => grounded;

        private void FixedUpdate()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit , playerHeight * .5f + raycastExtension, groundMask);

            if (grounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = 0;
            }
        }
    }
}

