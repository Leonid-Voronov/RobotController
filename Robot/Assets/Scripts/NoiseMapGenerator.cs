using UnityEngine;

namespace RobotDemo
{
    public class NoiseMapGenerator : MonoBehaviour
    {
        public float[,] GenerateNoiseMap (int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ, Wave[] waves)
        {
            float[,] noiseMap = new float[mapDepth, mapWidth];

            for (int zIndex = 0; zIndex < mapDepth; zIndex++) 
                for (int xIndex = 0; xIndex < mapWidth; xIndex++)
                {
                    float newX = (xIndex + offsetX) / scale;
                    float newZ = (zIndex + offsetZ) / scale;

                    float noise = 0f;
                    float normalization = 0f;

                    foreach (Wave wave in waves)
                    {
                        // generate noise value using PerlinNoise for a given Wave
                        noise += wave.Amplitude * Mathf.PerlinNoise(newX * wave.Frequency + wave.Seed, newZ * wave.Frequency + wave.Seed);
                        normalization += wave.Amplitude;
                    }
                    // normalize the noise value so that it is within 0 and 1
                    noise /= normalization;
                    noiseMap[zIndex, xIndex] = noise;
                }
            
            return noiseMap;
        }
    }
}

