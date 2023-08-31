using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RobotDemo
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private float seed;
        [SerializeField] private float frequency;
        [SerializeField] private float amplitude;

        public float Seed => seed;
        public float Frequency => frequency;
        public float Amplitude => amplitude;

        public void SetNewSeed(float newValue) { seed = newValue; }
    }
}
