using UnityEngine;
using UnityEngine.InputSystem;

namespace RobotDemo
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private InputAction moveAction;

        private Vector2 inputDirection; 
        public Vector2 InputDirection => inputDirection;

        private void Start()
        {
            InputActionMap playerActionMap = playerInput.actions.FindActionMap("Keyboard&Mouse", true);
            InputActions inputActions = new InputActions();
            string moveActionName = inputActions.KeyboardMouse.Move.name;
            moveAction = playerActionMap.FindAction(moveActionName);
        }

        private void Update()
        {
            inputDirection = moveAction.ReadValue<Vector2>();
        }


    }
}

