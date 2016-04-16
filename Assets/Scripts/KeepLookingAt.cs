using UnityEngine;
using System.Collections;

public class KeepLookingAt : MonoBehaviour {

  public GameObject lookAt;

  void Update() {
    transform.LookAt(lookAt.transform);
    transform.Rotate(Vector3.left * 10);
  }
}
