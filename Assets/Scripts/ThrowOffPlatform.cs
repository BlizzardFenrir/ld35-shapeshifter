using UnityEngine;
using System.Collections;

public class ThrowOffPlatform : MonoBehaviour {

  public float forceScale = 200.0f;

  private Vector3 initialPosition;
  private Quaternion initialRotation;
  private Rigidbody body;

	void Start () {
    initialPosition = transform.position;
    initialRotation = transform.rotation;
    body = GetComponent<Rigidbody>();
	}

  void OnEnable() {
    WinLoseEvent.OnLoseStage += OnLoseStage;
    ResetEvent.OnResetStage += OnResetStage;
  }

  void OnDisable() {
    WinLoseEvent.OnLoseStage -= OnLoseStage;
    ResetEvent.OnResetStage -= OnResetStage;
  }

  void OnLoseStage() {
    body.isKinematic = false;
    body.useGravity = true;
    body.AddForce(randomForce());
  }

  Vector3 randomForce() {
    var force = new Vector3();
    force.z = -forceScale;
    return force;
  }

  void OnResetStage() {
    transform.position = initialPosition;
    transform.rotation = initialRotation;
    body.isKinematic = true;
    body.useGravity = false;
    body.ResetInertiaTensor();
  }
}
