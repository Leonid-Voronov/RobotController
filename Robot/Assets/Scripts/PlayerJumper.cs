using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPD
{
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PlayerGroundChecker groundChecker;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;

        private bool readyToJump = true;
        private InputAction jumpAction;

        private void OnEnable()
        { 
            InputActions inputActions = new InputActions();
            string jumpActionName = inputActions.KeyboardMouse.Jump.name;
            jumpAction = playerInput.currentActionMap.FindAction(jumpActionName);
            jumpAction.performed += Jump;
        }

        private void ResetJump()
        {
            readyToJump = true;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (readyToJump && groundChecker.Grounded)
            {
                readyToJump = false;
                Invoke(nameof(ResetJump), jumpCooldown);
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void OnDisable()
        {
            jumpAction.performed -= Jump;
        }
    }
}

