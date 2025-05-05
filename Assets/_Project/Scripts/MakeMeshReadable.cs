using UnityEngine;

public class MakeMeshReadable : MonoBehaviour
{
    [Tooltip("Drag the GameObject with the mesh here")]
    public GameObject targetGameObject;

    [ContextMenu("Make Mesh Readable")]
    public void ProcessMesh() {
        if (targetGameObject == null) {
            Debug.LogError("Target GameObject is not assigned.");
            return;
        }

        MeshFilter meshFilter = targetGameObject.GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null) {
            Debug.LogError("Target GameObject does not have a MeshFilter or a mesh.");
            return;
        }

        Mesh originalMesh = meshFilter.sharedMesh;

        if (originalMesh.isReadable) {
            Debug.LogWarning("Mesh is already readable.", targetGameObject);
            return;
        }

        // Create a new mesh
        Mesh readableMesh = new Mesh();

        // Copy mesh data
        readableMesh.vertices = originalMesh.vertices;
        readableMesh.normals = originalMesh.normals;
        readableMesh.tangents = originalMesh.tangents;
        readableMesh.uv = originalMesh.uv;
        readableMesh.uv2 = originalMesh.uv2;
        readableMesh.uv3 = originalMesh.uv3;
        readableMesh.uv4 = originalMesh.uv4;
        readableMesh.colors = originalMesh.colors;
        readableMesh.colors32 = originalMesh.colors32;

        for (int i = 0; i < originalMesh.subMeshCount; i++) {
            readableMesh.SetTriangles(originalMesh.GetTriangles(i), i);
        }

        // Enable read/write on the new mesh
        // Note: isReadable is a read-only property at runtime,
        // but duplicating the mesh this way often results in a readable mesh.
        // To be absolutely sure, you might need to save it as an asset and reimport with read/write enabled.
        // However, for many use cases like outline generation, copying data is sufficient.

        // Assign the new mesh to the MeshFilter
        meshFilter.mesh = readableMesh;

        Debug.Log("Created a readable copy of the mesh.", targetGameObject);

        // You might want to save this new mesh as an asset if you need it persistently
        // UnityEditor.AssetDatabase.CreateAsset(readableMesh, "Assets/ReadableMeshes/" + targetGameObject.name + "_ReadableMesh.asset");
        // UnityEditor.AssetDatabase.SaveAssets();
    }
}