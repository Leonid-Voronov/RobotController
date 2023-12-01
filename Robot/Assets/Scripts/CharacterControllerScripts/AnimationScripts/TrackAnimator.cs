using UnityEngine;

namespace RobotDemo
{
    public class TrackAnimator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private WheelRotater _wheelRotater;

        [Header("Values")]
        [SerializeField] private string leftTrackSpeedParameter;
        [SerializeField] private string rightTrackSpeedParameter;
        [SerializeField] private float animationSpeedModifier;
        
        

        public void AnimateTracks(float newSpeed, Vector2 inputDirection, float groundMoveSpeed)
        {
            newSpeed *= animationSpeedModifier;

            float leftTrackDirectionAddition  = inputDirection.x < 0 ? -newSpeed : 0;
            float rightTrackDirectionAddition = inputDirection.x > 0 ? -newSpeed : 0;

            if (inputDirection.y == 0)
            {
                leftTrackDirectionAddition = inputDirection.x * groundMoveSpeed * animationSpeedModifier;
                rightTrackDirectionAddition = -inputDirection.x * groundMoveSpeed * animationSpeedModifier;
            }

            _wheelRotater.AnimateWheels(newSpeed + leftTrackDirectionAddition, newSpeed + rightTrackDirectionAddition);

            _animator.SetFloat(leftTrackSpeedParameter, newSpeed + leftTrackDirectionAddition);
            _animator.SetFloat(rightTrackSpeedParameter, newSpeed + rightTrackDirectionAddition);
        }

        public void StopAnimation()
        {
            _animator.SetFloat(leftTrackSpeedParameter, 0f);
            _animator.SetFloat(rightTrackSpeedParameter, 0f);
        }
    }
}

