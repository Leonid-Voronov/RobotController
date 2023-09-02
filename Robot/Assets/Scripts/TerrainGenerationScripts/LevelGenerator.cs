using UnityEngine;

namespace RobotDemo
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject tilePrefab;
        [SerializeField] private int mapWidthInTiles, mapDepthInTiles;
        [SerializeField] private Wave[] waves;
        private GameObject terrainObject;

        private const string generatedTerrainName = "Generated Terrain";

        private void Start()
        {
            if (gameObject.transform.childCount == 0)
            {
                GenerateMap();
            }
        }

        public void GenerateMap()
        {
            if (gameObject.transform.childCount > 0)
                DestroyTerrainObjects();

            terrainObject = GenerateTerrainParentObject();
            RegenerateSeeds();


            Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
            int tileWidth = (int)tileSize.x;
            int tileDepth = (int)tileSize.z;

            for (int xTileIndex = 0; xTileIndex < mapWidthInTiles; xTileIndex++)
                for (int zTileIndex = 0; zTileIndex < mapDepthInTiles; zTileIndex++) 
                {
                    Vector3 tilePosition = new Vector3(
                        gameObject.transform.position.x + xTileIndex * tileWidth,
                        gameObject.transform.position.y,
                        gameObject.transform.position.z + zTileIndex * tileDepth);

                    GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                    tile.transform.parent = terrainObject.transform;
                    TileGenerator tileGenerator = tile.GetComponent<TileGenerator>();
                    tileGenerator.GenerateTile();
                }
        }

        private GameObject GenerateTerrainParentObject()
        {
            GameObject newTerrain = new GameObject();
            newTerrain.transform.parent = gameObject.transform;
            newTerrain.name = generatedTerrainName;
            return newTerrain;
        }

        private void DestroyTerrainObjects()
        {
            int childCount = gameObject.transform.childCount;
            #if UNITY_EDITOR
                for (int i = 0; i < childCount; i++)
                    DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            #else
                for (int i = 0; i < childCount; i++)
                    Destroy(gameObject.transform.GetChild(0).gameObject);
            #endif
        }

        private void RegenerateSeeds()
        {
            foreach (Wave wave in waves)
            {
                wave.SetNewSeed(Random.value * 10000);
            }
        }

        public Wave[] Waves => waves;
    }
}

