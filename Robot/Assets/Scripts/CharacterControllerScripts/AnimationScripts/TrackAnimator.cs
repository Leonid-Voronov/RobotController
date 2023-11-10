using UnityEngine;

namespace RobotDemo
{
    public class TrackAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string leftTrackSpeedParameter;
        [SerializeField] private string rightTrackSpeedParameter;

        public void AnimateTracks(float newSpeed)
        {
            _animator.SetFloat(leftTrackSpeedParameter, newSpeed);
            _animator.SetFloat(rightTrackSpeedParameter, newSpeed);
        }
    }
}

