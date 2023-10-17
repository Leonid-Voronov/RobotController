using UnityEngine;

namespace RobotDemo
{
    public class HeadRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Transform headTransform;
        [SerializeField] private PlayerGroundChecker playerGroundChecker;

        public void RotateHead(Vector3 cameraDirection)
        {

            headTransform.rotation = transform.rotation;
            headTransform.Rotate(-90, 0, 0);
            headTransform.Rotate(0, 0, 90);

            if (playerGroundChecker.Grounded)
            {
                float cameraAngle = Mathf.Atan2(cameraDirection.z, cameraDirection.x) * Mathf.Rad2Deg;
                float modelAngle = Mathf.Atan2(transform.forward.z, transform.forward.x) * Mathf.Rad2Deg;
                float deltaAngle = modelAngle - cameraAngle;
                headTransform.Rotate(0, 0, deltaAngle);
            }
        }

        public void ResetRotation()
        {
            headTransform.localRotation = Quaternion.identity;
        }

    }
}

