using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TransformMesh {
   public string Name;
   [HideInInspector]
   public char Key;
   public GameObject Value;
}

public class VertexTransform : MonoBehaviour {
  public List<TransformMesh> transformMeshes;
  private Dictionary<char, List<Vector3> > transformOffsets;

  [HideInInspector][System.NonSerialized]
  private TweenKeypresses keypresses;
  [HideInInspector][System.NonSerialized]
  private Mesh mesh;
  [HideInInspector][System.NonSerialized]
  private Vector3[] initialVertices;

  // Use this for initialization
  void Start () {
    transformOffsets = new Dictionary<char, List<Vector3> >();
    keypresses = GetComponent<TweenKeypresses>();

    mesh = GetComponent<MeshFilter>().mesh;
    initialVertices = mesh.vertices;

    foreach (TransformMesh tfm in transformMeshes) {
      Mesh trMesh = tfm.Value.GetComponent<MeshFilter>().sharedMesh;
      Vector3[] transformVertices = trMesh.vertices;

      List<Vector3> offsets = new List<Vector3>();

      for (int i = 0; i < initialVertices.Length; i++) {
        offsets.Add( transformVertices[i] - initialVertices[i] );
      }
      transformOffsets[tfm.Key] = offsets;
    }
  }
  
  // Update is called once per frame
  void Update () {
    Vector3[] vertices = new Vector3[initialVertices.Length];
    System.Array.Copy(initialVertices, vertices, initialVertices.Length);

    foreach (KeyValuePair<char, List<Vector3> > kvp in transformOffsets) {
      for (int j = 0; j < vertices.Length; j++) {
        vertices[j] += kvp.Value[j] * keypresses.ScaleFactor(kvp.Key);
      }
    }

    mesh.vertices = vertices;
    mesh.RecalculateBounds();
  }

  void OnValidate() {
    foreach (TransformMesh tfm in transformMeshes) {
      if (tfm.Name.Length > 0) {
        tfm.Key = tfm.Name[0];
      }
    }
  }

}
