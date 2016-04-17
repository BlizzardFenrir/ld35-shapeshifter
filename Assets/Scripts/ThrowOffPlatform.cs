using UnityEngine;
using System.Collections;

public class ThrowOffPlatform : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

  void OnTriggerEnter(Collider other) {
    Debug.Log("COLLIDE");
  }
}
