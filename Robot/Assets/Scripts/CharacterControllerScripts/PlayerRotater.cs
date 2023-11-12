using UnityEngine;

namespace RobotDemo
{
    public class PlayerRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Transform playerObjectTransform;
        [SerializeField] private Input input;
        [SerializeField] private PlayerGroundChecker playerGroundChecker;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private EngineCore engineCore;

        [Header("Values")]
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float kSoftness;
        private void Update()
        {
            Vector3 forwardRotationDirection = playerObjectTransform.right * input.InputDirection.x * Mathf.Sign(input.InputDirection.y);

            Vector3 newForward = playerObjectTransform.forward;
            if (forwardRotationDirection != Vector3.zero)
            {
                newForward = Vector3.Slerp(playerObjectTransform.forward, forwardRotationDirection.normalized, Time.deltaTime * rotationSpeed);
            }

            Vector3 newUp = playerGroundChecker.Grounded ? playerGroundChecker.HitNormal : rb.transform.up;

            Vector3 left = Vector3.Cross(newForward, newUp);
            newForward = Vector3.Cross(newUp, left);
            Quaternion newRotation = Quaternion.LookRotation(newForward, newUp);

            if (!engineCore.FlyInput)
                rb.MoveRotation(Quaternion.Lerp(playerObjectTransform.rotation, newRotation, kSoftness));
        }


    }
}

