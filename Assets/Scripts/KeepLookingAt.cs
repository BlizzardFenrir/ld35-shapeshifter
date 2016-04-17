using UnityEngine;
using System.Collections;

public class KeepLookingAt : MonoBehaviour {
  public float wallPlace = 0.0f;
  public float dampTime = 0.2f;
  public GameObject lookAt;

  private Vector3 initialPosition;
  private Vector3 desiredPosition;
  private Vector3 currentVelocity;


  void Start() { 
    initialPosition = transform.position;
    desiredPosition = initialPosition;
  }

  void Update() {
    var yOffset =  -1.5f * Mathf.Cos (Mathf.PI * wallPlace) + 1.5f;
    desiredPosition.y = initialPosition.y - yOffset;
    desiredPosition.z = initialPosition.z - 3.5f * wallPlace;

	  transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, dampTime);
	  transform.LookAt(lookAt.transform);
    transform.Rotate(Vector3.left * 10);
  }
}
