using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    void Start()
    {
        CombineMeshes();
    }

    void CombineMeshes()
    {
        // Get all the MeshFilters in children
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        // Create arrays to hold mesh data
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        // Iterate through each child and store their mesh data
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            // Disable child renderers to hide original meshes
            // meshFilters[i].gameObject.SetActive(false);
        }

        // Create a new mesh for the combined meshes
        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine, true);

        // Get or add a MeshCollider component on the parent object
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (meshCollider == null)
        {
            meshCollider = gameObject.AddComponent<MeshCollider>();
        }

        // Assign the combined mesh to the MeshCollider
        meshCollider.sharedMesh = combinedMesh;
    }
}
