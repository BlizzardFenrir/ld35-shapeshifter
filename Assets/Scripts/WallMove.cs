using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {
  public float speed;
  public bool moving = false;
  public KeepLookingAt cameraMovement;
  public GameObject wallShape;

  void Start() {
    ResetWall();
  }

  void Update () {
    if (Input.anyKey) {
      moving = true;
    }

    if (moving) {
      var translation = new Vector3(0.0f, 0.0f, speed) * Time.deltaTime;
      transform.position += translation;
    }

    if (transform.position.z < -10) {
      ResetWall();
    }
    cameraMovement.wallPlace = 1 - ((transform.position.z + 10) / 38.0f);
  }

  void ResetWall() {
    wallShape.GetComponent<RandomKeypresses>().Randomize();
    transform.position = new Vector3(transform.position.x, transform.position.y, 28);
    moving = false;
  }
}
