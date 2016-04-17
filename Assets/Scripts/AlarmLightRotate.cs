using UnityEngine;
using System.Collections;

public class AlarmLightRotate : MonoBehaviour {
  public bool rotating = true;

  void Start() {
  }
	
  void Update() {
    if (rotating) {
      transform.Rotate(Vector3.forward * Time.deltaTime * 500, Space.World);
    } else {
      transform.rotation = new Quaternion(0, 0, 0, 0);
    }
  }
}