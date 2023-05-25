using UnityEngine;

public class ClothBehavior : MonoBehaviour
{
    private void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, 0.5f, 0),
            new Vector3(0.5f, 0.5f, 0),
            new Vector3(0.5f, -0.5f, 0),
            new Vector3(-0.5f, -0.5f, 0)
        };
        mesh.triangles = new int[]
        {
            0, 1, 2,
            2, 3, 0
        };
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
