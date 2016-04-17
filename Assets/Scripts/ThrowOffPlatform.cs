using UnityEngine;
using System.Collections;

public class ThrowOffPlatform : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

  void OnCollisionEnter(Collision collision) {
    Debug.Log("COLLIDE");
  }
}
