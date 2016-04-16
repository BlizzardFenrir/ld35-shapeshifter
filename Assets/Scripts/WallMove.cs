using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {
  public float speed;

  void Update () {
    transform.position += new Vector3(0.0f, 0.0f, speed) * Time.deltaTime;
  }
}
