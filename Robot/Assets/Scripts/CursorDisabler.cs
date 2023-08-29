using UnityEngine;

namespace RobotDemo
{
    public class CursorDisabler : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

