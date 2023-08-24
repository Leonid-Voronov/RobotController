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
            Vector3 rotationDirection = orientationTransform.forward * input.InputDirection.y + orientationTransform.right * input.InputDirection.x;
            if (rotationDirection != Vector3.zero)
                playerObjectTransform.forward = Vector3.Slerp(playerObjectTransform.forward, rotationDirection.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}

