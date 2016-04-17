using UnityEngine;
using System.Collections;

public class AudienceReactions : MonoBehaviour {
  public float minTimeBetweenJumps;
  public float maxTimeBetweenJumps;
  public float minJumpHeight;
  public float maxJumpHeight;
  public float winJumpHeight;

  private float nextJumpTime;

  [HideInInspector][System.NonSerialized]
  private Rigidbody rb;

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }

  void Start() {
    determineNextJumpTime();
  }

  // Update is called once per frame
  void Update () {
    if (Time.time > nextJumpTime) {
      jump();
      determineNextJumpTime();
    }
  }

  public void determineNextJumpTime() {
    nextJumpTime = Time.time + Random.Range(minTimeBetweenJumps, maxTimeBetweenJumps);
  }

  public void jump() {
    float jumpHeight = Random.Range(minJumpHeight, maxJumpHeight);
    rb.velocity = new Vector3(0, jumpHeight, 0);
  }

  public void winJump() {
    nextJumpTime = Random.Range(0.0f, 1.0f);
  }
}
