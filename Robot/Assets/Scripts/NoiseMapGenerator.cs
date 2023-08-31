using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDemo
{

    public class NoiseMapGenerator : MonoBehaviour
    {
        public float[,] GenerateNoiseMap (int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ)
        {
            float[,] noiseMap = new float[mapDepth, mapWidth];

            for (int zIndex = 0; zIndex < mapDepth; zIndex++) 
                for (int xIndex = 0; xIndex < mapWidth; xIndex++)
                {
                    float newX = (xIndex + offsetX) / scale;
                    float newZ = (zIndex + offsetZ) / scale;

                    float noise = Mathf.PerlinNoise(newX, newZ);
                    noiseMap[zIndex, xIndex] = noise;
                }
            
            return noiseMap;
        }
    }
}

