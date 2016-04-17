using UnityEngine;
using System.Collections;

public class AudienceReactions : MonoBehaviour {
  public float minTimeBetweenJumps;
  public float maxTimeBetweenJumps;
  public float minJumpHeight;
  public float maxJumpHeight;
  public float winJumpHeight;

  // private float startingHeight;
  private float nextJumpTime;

  void Start() {
    // startingHeight = transform.position.y;
    nextJumpTime = Time.time + Random.Range(minTimeBetweenJumps, maxTimeBetweenJumps);
  }

  // Update is called once per frame
  void Update () {
    if (Time.time > nextJumpTime) {
      Jump();
    }

    // if (transform.position.z < startingHeight)
    //   transform.position = new Vector3(transform.position.x, transform.position.y, startingHeight);
  }

  public void Jump() {
    float jumpHeight = Random.Range(minJumpHeight, maxJumpHeight);

  }
}
