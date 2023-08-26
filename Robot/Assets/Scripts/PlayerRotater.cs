using UnityEngine;

namespace TPD
{
    public class PlayerRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Transform playerObjectTransform;
        [SerializeField] private Transform orientationTransform;
        [SerializeField] private Input input;
        [SerializeField] private PlayerGroundChecker playerGroundChecker;
        [SerializeField] private Rigidbody rb;

        [Header("Values")]
        [SerializeField] private float rotationSpeed;
        [SerializeField] private AnimationCurve rotationCurve;
        [SerializeField] private float normalAligmentTime;

        private void Update()
        {
            Vector3 forwardRotationDirection = playerObjectTransform.right * input.InputDirection.x * Mathf.Sign(input.InputDirection.y);

            /*if (forwardRotationDirection != Vector3.zero)
            {
                playerObjectTransform.forward = Vector3.Slerp(playerObjectTransform.forward, forwardRotationDirection.normalized, Time.deltaTime * rotationSpeed);
                orientationTransform.forward = Vector3.Slerp(playerObjectTransform.forward, forwardRotationDirection.normalized, Time.deltaTime * rotationSpeed);
            }

            Quaternion rotationReference = Quaternion.Euler(0f,0f,0f);
           
            if (playerGroundChecker.Grounded)
            {
                Debug.Log(playerGroundChecker.HitNormal);
                Quaternion fromToRotation = Quaternion.FromToRotation(Vector3.up, playerGroundChecker.HitNormal);
                rotationReference = Quaternion.Lerp(playerObjectTransform.rotation, fromToRotation, rotationCurve.Evaluate(normalAligmentTime));
                //orientationTransform.rotation = Quaternion.LookRotation(orientationTransform.forward, playerGroundChecker.HitNormal);

                //playerObjectTransform.up = Vector3.Slerp(playerObjectTransform.up, playerGroundChecker.HitNormal, Time.deltaTime * rotationSpeed);
                //orientationTransform.up = Vector3.Slerp(orientationTransform.up, playerGroundChecker.HitNormal, Time.deltaTime * rotationSpeed);
            }
            
            playerObjectTransform.rotation = Quaternion.Euler(rotationReference.eulerAngles.x, playerObjectTransform.eulerAngles.y, rotationReference.eulerAngles.z);


            Quaternion oldRotation = playerObjectTransform.rotation;*/

            Vector3 newForward = playerObjectTransform.forward;
            if (forwardRotationDirection != Vector3.zero)
            {
                newForward = Vector3.Slerp(playerObjectTransform.forward, forwardRotationDirection.normalized, Time.deltaTime * rotationSpeed);
            }

            Vector3 newUp;
            if (playerGroundChecker.Grounded)
            {
                newUp = playerGroundChecker.HitNormal;
            }
            else
            {
                newUp = Vector3.up;
            }

            Vector3 left = Vector3.Cross(newForward, newUp);
            newForward = Vector3.Cross(newUp, left);
            Quaternion newRotation = Quaternion.LookRotation(newForward, newUp);

            float kSoftness = .05f;
            rb.MoveRotation(Quaternion.Lerp(playerObjectTransform.rotation, newRotation, kSoftness));
        }


    }
}

