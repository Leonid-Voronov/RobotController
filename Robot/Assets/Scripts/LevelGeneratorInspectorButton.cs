using UnityEngine;

namespace RobotDemo
{
    [RequireComponent (typeof(LevelGenerator))]
    public class LevelGeneratorInspectorButton : MonoBehaviour
    {
        private LevelGenerator levelGenerator;
        public void OnButtonClick()
        {
            if (levelGenerator == null)
                levelGenerator = gameObject.GetComponent<LevelGenerator>();

            levelGenerator.GenerateMap();
        }
    }
}

