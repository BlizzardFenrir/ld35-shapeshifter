using UnityEngine;
using System.Collections;

public class ThrowOffPlatform : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

  void OnTriggerEnter(Collider other) {
    Debug.Log("COLLIDE");
    var body = GetComponent<Rigidbody>();
    body.isKinematic = false;
    body.useGravity = true;
    body.AddForce(randomForce());
  }

  Vector3 randomForce() {
    var force = new Vector3();
    force.z = -100;
    return force;
  }
}
