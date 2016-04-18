using UnityEngine;
using System.Collections;

public class FloatOnWater : MonoBehaviour {
  public Transform water;
  public float scaleFactor;
  public ParticleSystem splashParticles;
  public AudioSource splashSound;
  private Rigidbody body;

  // Use this for initialization
  void Start () {
    body = GetComponent<Rigidbody>();
  }
  
  // Update is called once per frame
  void Update () {
    if (transform.position.y < water.position.y) {
      // Dampen x/z directions (not realistic but doesn't matter)
      body.velocity = new Vector3(body.velocity.x * 0.5f,
                                  body.velocity.y * 0.9f,
                                  body.velocity.z * 0.5f);
      // Add upward force
      body.AddForce( new Vector3(0.0f, scaleFactor * (water.position.y - transform.position.y), 0.0f) );
    }
  }
}
