using UnityEngine;

namespace TPD
{
    public class ThirdPersonCam : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform orientation;
        [SerializeField] private Transform player;
        [SerializeField] private Transform playerGfx;

        private void Update()
        {
            Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            //orientation.forward = viewDirection.normalized;


        }
    }
}

