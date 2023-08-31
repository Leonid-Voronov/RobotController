using UnityEditor;
using UnityEngine;

namespace RobotDemo
{
    [CustomEditor(typeof(LevelGeneratorInspectorButton)), CanEditMultipleObjects]
    public class TerrainGenerationButton : Editor
    {
        public override void OnInspectorGUI()
        {
            LevelGeneratorInspectorButton levelGeneratorButton = (LevelGeneratorInspectorButton)target;
            if (GUILayout.Button("Regenerate Terrain"))
            {
                levelGeneratorButton.OnButtonClick();
            }
        }
    }
}

