using UnityEngine;
using System.Collections;

public class KeepLookingAt : MonoBehaviour {

  public Vector3 desiredPosition;
  private Vector3 currentVelocity;
  public float wallPlace = 0.0f;
  public float dampTime = 0.2f;
  private Vector3 initialPosition;

  public GameObject lookAt;

  void Start() { 
    initialPosition = transform.position;
    desiredPosition = initialPosition;
  }

  void Update() {
	  transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, dampTime);

	  transform.LookAt(lookAt.transform);
    transform.Rotate(Vector3.left * 10);
  }
}
