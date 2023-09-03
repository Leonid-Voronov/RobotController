using UnityEngine;
using UnityEngine.InputSystem;

namespace RobotDemo
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerFlyingEngine playerFlyingEngine;
        private InputAction moveAction;

        private Vector2 inputDirection; 
        public Vector2 InputDirection => inputDirection;
        private InputActions inputActions;

        private void Start()
        {
            InputActionMap playerActionMap = playerInput.actions.FindActionMap("Keyboard&Mouse", true);
            inputActions = new InputActions();
            string moveActionName = inputActions.KeyboardMouse.Move.name;
            moveAction = playerActionMap.FindAction(moveActionName);

            inputActions.Enable();
            inputActions.KeyboardMouse.Fly.performed += JetInput;
        }

        private void Update()
        {
            inputDirection = moveAction.ReadValue<Vector2>();
        }

        private void JetInput(InputAction.CallbackContext context)
        {
            playerFlyingEngine.ToggleFlyInput();
        }

        private void OnDisable()
        {
            inputActions.KeyboardMouse.Fly.performed -= JetInput;
        }
    }
}

