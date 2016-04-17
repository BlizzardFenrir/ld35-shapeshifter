using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomBlink : MonoBehaviour {

  public GameObject blinkObject;
  private List<Vector3> blinkOffsets;

  public float nextBlinkTime;

  [HideInInspector][System.NonSerialized]
  private Mesh mesh;

  // Use this for initialization
  void Awake() {
    mesh = GetComponent<MeshFilter>().mesh;
  }

  void Start () {
    blinkOffsets = new List<Vector3>();

    Mesh blinkMesh = blinkObject.GetComponent<MeshFilter>().sharedMesh;
    Vector3[] transformVertices = blinkMesh.vertices;
    Vector3[] vertices = mesh.vertices;

    for (int i = 0; i < vertices.Length; i++) {
     blinkOffsets.Add( transformVertices[i] - vertices[i] );
    }

    nextBlinkTime = Time.time + Random.Range(1.0f, 10.0f);
 }

  // Update is called once per frame
  void Update () {
    float animationLength = 0.5f;

    if (Time.time > nextBlinkTime) {
      float deltaTime = nextBlinkTime - Time.time;
      float eased = EasingFunctions.EaseOutElastic(deltaTime, 0, 1, animationLength);
      float scalefactor = Mathf.Clamp(eased, 0.0f, 1.0f);

      Vector3[] vertices = GetComponent<MeshFilter>().mesh.vertices;
      for (int i = 0; i < vertices.Length; i++) {
        vertices[i] += blinkOffsets[i] * scalefactor;
      }

      mesh.vertices = vertices;
      mesh.RecalculateBounds();
    }
  }
}
