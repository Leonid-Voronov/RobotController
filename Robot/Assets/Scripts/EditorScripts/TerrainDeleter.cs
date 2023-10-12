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
            EditorApplication.quitting += DeleteTerrain;
        }
        
        private static void DeleteTerrain()
        {
            LevelGenerator levelGenerator = Object.FindFirstObjectByType<LevelGenerator>();
            Object.Destroy(levelGenerator.transform.GetChild(0));
            EditorApplication.quitting -= DeleteTerrain;
        }
    }
}
#endif
