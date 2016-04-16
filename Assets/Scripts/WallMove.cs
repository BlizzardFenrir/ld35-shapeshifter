using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {
  public float speed;
  public Camera camera;

  void Update () {
    var translation = new Vector3(0.0f, 0.0f, speed) * Time.deltaTime;
    transform.position += translation;
    camera.transform.position += translation * 0.1f;
  }
}
