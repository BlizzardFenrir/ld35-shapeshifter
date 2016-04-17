using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {
  public float speed;
  public bool moving = false;
  public KeepLookingAt cameraMovement;
  public GameObject wallShape;

  private float initialSpeed;
  private Color initialColor;
  private float currentAlpha;
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
    initialColor = GetComponent<Renderer>().material.color;
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
    currentAlpha = 5.0f - 5.0f*cameraMovement.wallPlace;
    GetComponent<Renderer>().material.color = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Clamp(currentAlpha, 0.0f, 1.0f));
  }

  void ResetWall() {
    transform.position = new Vector3(transform.position.x, transform.position.y, 28);
    moving = false;
    speed = initialSpeed;
    speedIncrease = 0.0f;
    GetComponent<Renderer>().material.color = initialColor;
    currentAlpha = initialColor.a;
  }

  void SpeedUpWin() {
    speedIncrease = 0.2f;
  }

  void SpeedUpLose() {
    speedIncrease = 0.05f;
  }
}
