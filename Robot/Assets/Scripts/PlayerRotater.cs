using UnityEngine;

namespace TPD
{
    public class PlayerRotater : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Transform playerObjectTransform;
        [SerializeField] private Transform orientationTransform;
        [SerializeField] private Input input;

        [Header("Values")]
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            Vector3 rotationDirection = playerObjectTransform.right * input.InputDirection.x * Mathf.Sign(input.InputDirection.y);
            if (rotationDirection != Vector3.zero)
            {
                playerObjectTransform.forward = Vector3.Slerp(playerObjectTransform.forward, rotationDirection.normalized, Time.deltaTime * rotationSpeed);
                orientationTransform.forward = Vector3.Slerp(playerObjectTransform.forward, rotationDirection.normalized, Time.deltaTime * rotationSpeed);
            }
                
        }
    }
}

