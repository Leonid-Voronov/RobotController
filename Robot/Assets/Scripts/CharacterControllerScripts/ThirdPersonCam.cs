using UnityEngine;
using UnityEngine.UIElements;

namespace RobotDemo
{
    public class ThirdPersonCam : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform orientation;
        [SerializeField] private Transform player;
        [SerializeField] private PlayerGroundChecker playerGroundChecker;
        [SerializeField] private HeadRotater headRotater;

        [Header("Values")]
        [SerializeField] private float modelRotationSpeed;
        private void FixedUpdate()
        {
            float newViewDirectionY = playerGroundChecker.Grounded ? player.position.y : transform.position.y;
            Vector3 viewDirection = player.position - new Vector3(transform.position.x, newViewDirectionY, transform.position.z);


            if (!playerGroundChecker.Grounded)
            {
                orientation.forward = viewDirection.normalized;
                player.forward = Vector3.Slerp(player.forward, orientation.forward, modelRotationSpeed * Time.fixedDeltaTime);
                headRotater.ResetRotation();
            }
            else
            {
                headRotater.RotateHead(viewDirection.normalized);
            }

            
        }
    }
}

