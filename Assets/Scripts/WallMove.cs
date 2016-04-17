using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {
  public float speed;
  public bool moving = false;
  public KeepLookingAt cameraMovement;
  public GameObject wallShape;

  private float initialSpeed;
  private float speedIncrease;

  void OnEnable() {
    ResetEvent.OnResetStage += ResetWall;
    WinLoseEvent.OnWinStage += SpeedUpWin;
    WinLoseEvent.OnLoseStage += SpeedUpLose;
  }

  void OnDisable() {
    ResetEvent.OnResetStage -= ResetWall;
    WinLoseEvent.OnWinStage -= SpeedUpWin;
    WinLoseEvent.OnLoseStage -= SpeedUpLose;
  }

  void Start() {
    initialSpeed = speed;
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

    speed -= speedIncrease;

    cameraMovement.wallPlace = 1 - ((transform.position.z + 10) / 38.0f);
  }

  void ResetWall() {
    transform.position = new Vector3(transform.position.x, transform.position.y, 28);
    moving = false;
    speed = initialSpeed;
    speedIncrease = 0.0f;
  }

  void SpeedUpWin() {
    speedIncrease = 0.2f;
  }

  void SpeedUpLose() {
    speedIncrease = 0.1f;
  }
}
