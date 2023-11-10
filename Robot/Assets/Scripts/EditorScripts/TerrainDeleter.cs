using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR) 
namespace RobotDemo
{
    [InitializeOnLoad]
    public static class TerrainDeleter
    {
        static TerrainDeleter()
        {
            Debug.Log("Initialized");
            EditorApplication.quitting += DeleteTerrain;
        }
        
        private static void DeleteTerrain()
        {
            Debug.Log("Af");
            LevelGenerator levelGenerator = Object.FindFirstObjectByType<LevelGenerator>();
            Object.Destroy(levelGenerator.transform.GetChild(0));
            EditorApplication.quitting -= DeleteTerrain;
        }
    }
}
#endif
