using UnityEngine;
using System.Collections;

public class AudienceReactions : MonoBehaviour {
  public float minTimeBetweenJumps;
  public float maxTimeBetweenJumps;
  public float minJumpHeight;
  public float maxJumpHeight;
  public float winJumpHeight;

  private float nextJumpTime;
  private float nextJumpHeight;

  [HideInInspector][System.NonSerialized]
  private Rigidbody rb;

  void OnEnable() {
    WinLoseEvent.OnWinStage += winJump;
  }

  void OnDisable() {
    WinLoseEvent.OnWinStage -= winJump;
  }

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }

  void Start() {
    determineNextJump();
  }

  // Update is called once per frame
  void Update () {
    if (Time.time > nextJumpTime) {
      jump();
      determineNextJump();
    }
  }

  public void determineNextJump() {
    nextJumpTime = Time.time + Random.Range(minTimeBetweenJumps, maxTimeBetweenJumps);
    nextJumpHeight = Random.Range(minJumpHeight, maxJumpHeight);
  }

  public void jump() {
    rb.velocity = new Vector3(0, nextJumpHeight, 0);
  }

  public void winJump() {
    nextJumpTime = Time.time + Random.Range(0.0f, 1.0f) + 1.0f;
    nextJumpHeight = winJumpHeight;
  }
}
