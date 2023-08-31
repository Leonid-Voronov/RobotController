using UnityEngine;

namespace RobotDemo
{
    public class TileGenerator : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private NoiseMapGenerator noiseMapGeneration;
        [SerializeField] private MeshRenderer tileRenderer;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshCollider meshCollider;

        [Header("Values")]
        [SerializeField] private float mapScale;
        [SerializeField] private float heightMultiplier;

        public void GenerateTile()
        {
            Mesh mesh = GetMeshCopy();

            Vector3[] meshVertices = mesh.vertices;
            int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
            int tileWidth = tileDepth;

            float offsetX = - gameObject.transform.position.x;
            float offsetZ = - gameObject.transform.position.z;

            float[,] heightMap = noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, mapScale, offsetX, offsetZ);

            Texture2D tileTexture = BuildTexture(heightMap);
            GetMaterialCopy().mainTexture = tileTexture;
            UpdateMeshVertices(heightMap, mesh);
        }

        private Texture2D BuildTexture(float[,] heightMap)
        {
            int tileDepth = heightMap.GetLength(0);
            int tileWidth = heightMap.GetLength(1);

            Color[] colorMap = new Color[tileDepth * tileWidth];
            for (int zIndex = 0; zIndex < tileDepth; zIndex++)
                for (int xIndex = 0; xIndex < tileWidth; xIndex++)
                {
                    int colorIndex = zIndex * tileWidth + xIndex;
                    float height = heightMap[zIndex, xIndex];
                    colorMap[colorIndex] = Color.Lerp(Color.black, Color.white, height);
                }

            Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
            tileTexture.wrapMode = TextureWrapMode.Clamp;
            tileTexture.SetPixels(colorMap);
            tileTexture.Apply();

            return tileTexture;
        }

        private void UpdateMeshVertices(float[,] heightMap, Mesh mesh)
        {
            int tileDepth = heightMap.GetLength(0);
            int tileWidth = heightMap.GetLength(1);

            Vector3[] meshVertices = mesh.vertices;

            int vertexIndex = 0;
            for (int zIndex = 0; zIndex < tileDepth; zIndex++)
                for (int xIndex = 0; xIndex < tileWidth; xIndex++) 
                {
                    float height = heightMap[zIndex, xIndex];

                    Vector3 vertex = meshVertices[vertexIndex];
                    meshVertices[vertexIndex] = new Vector3(vertex.x, height * heightMultiplier, vertex.z);
                    vertexIndex++;
                }

            mesh.vertices = meshVertices;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            meshCollider.sharedMesh = mesh;
        }

        private Mesh GetMeshCopy()
        {
            Mesh mesh;
            #if UNITY_EDITOR
                        //Only do this in the editor
                        meshFilter = GetComponent<MeshFilter>();   //a better way of getting the meshfilter using Generics
                        Mesh meshCopy = Mesh.Instantiate(meshFilter.sharedMesh) as Mesh;  //make a deep copy
                        mesh = meshFilter.mesh = meshCopy;                    //Assign the copy to the meshes
            #else
                            //do this in play mode
                            mesh = GetComponent<MeshFilter>().mesh;
            #endif
            return mesh;
        }

        private Material GetMaterialCopy() 
        {
            Material material;
            #if UNITY_EDITOR
                //Only do this in the editor
                tileRenderer = GetComponent<MeshRenderer>();   
                Material materialCopy = Material.Instantiate(tileRenderer.sharedMaterial) as Material;  //make a deep copy
                material = tileRenderer.material = materialCopy;                    //Assign the copy to the meshes
            #else
                //do this in play mode
                material = GetComponent<MeshRenderer>.material;
            #endif
            return material;
        }
    }
}

