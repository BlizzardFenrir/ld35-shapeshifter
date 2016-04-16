using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VertexTransform : MonoBehaviour {
  
  public List<GameObject> transformMeshes;
  private List< List<Vector3> > transformOffsets;
  float[] buttonsPressed;

  [HideInInspector][System.NonSerialized]
  private Mesh mesh;
  [HideInInspector][System.NonSerialized]
  private Vector3[] initialVertices;

  // Use this for initialization
  void Start () {
    transformOffsets = new List< List<Vector3> >();
    buttonsPressed = new float[26];

    mesh = GetComponent<MeshFilter>().mesh;
    initialVertices = mesh.vertices;

    foreach (GameObject tr in transformMeshes) {
      Mesh trMesh = tr.GetComponent<MeshFilter>().sharedMesh;
      Vector3[] transformVertices = trMesh.vertices;

      List<Vector3> offsets = new List<Vector3>();

      for (int i = 0; i < initialVertices.Length; i++) {
        offsets.Add( transformVertices[i] - initialVertices[i] );
      }
      transformOffsets.Add( offsets );
    }
  }
  
  // Update is called once per frame
  void Update () {
    if (Input.GetKey(KeyCode.Q)) {
      buttonsPressed[0] = Mathf.Clamp(buttonsPressed[0] + 0.1f, 0.0f, 1.0f);
    } else {
      buttonsPressed[0] = Mathf.Clamp(buttonsPressed[0] - 0.1f, 0.0f, 1.0f);
    }


    Vector3[] vertices = new Vector3[initialVertices.Length];
    System.Array.Copy(initialVertices, vertices, initialVertices.Length);

    for (int i = 0; i < transformOffsets.Count; i++) {
      for (int j = 0; j < vertices.Length; j++) {
        vertices[j] += transformOffsets[i][j] * buttonsPressed[i];
      }
    }

    mesh.vertices = vertices;
    mesh.RecalculateBounds();
  }

}
