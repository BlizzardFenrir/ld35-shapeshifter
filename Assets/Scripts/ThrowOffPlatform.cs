using UnityEngine;
using System.Collections;

public class ThrowOffPlatform : MonoBehaviour {

  private Vector3 initialPosition;
  private Quaternion initialRotation;

	void Start () {
    initialPosition = transform.position;
    initialRotation = transform.rotation;
	}

  void OnEnable() {
    WinLoseEvent.OnWinStage += OnWinStage;
    WinLoseEvent.OnLoseStage += OnLoseStage;
    ResetEvent.OnResetStage += OnResetStage;
  }

  void OnDisable() {
    WinLoseEvent.OnWinStage -= OnWinStage;
    WinLoseEvent.OnLoseStage -= OnLoseStage;
    ResetEvent.OnResetStage -= OnResetStage;
  }

  void OnWinStage ()
  {
    Debug.Log("WIN");
  }

  void OnLoseStage() {
    Debug.Log("LOSE");

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

  void OnResetStage() {
    transform.position = initialPosition;
    transform.rotation = initialRotation;
  }
}
