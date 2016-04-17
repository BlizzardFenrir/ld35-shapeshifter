using UnityEngine;
using System.Collections;

public class AudienceMemberMovement : MonoBehaviour {
  public float shiftAmount = 0.2f;
  public double shiftChance = 0.05;

  [System.NonSerialized]
  private System.Random rng;
  private bool shiftedUp = false;
  private bool shiftedLeft = false;
  private bool shiftedRight = false;
  private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
    rng = new System.Random();
    initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    RandomizePosition();
    transform.position = initialPosition;

    transform.position = new Vector3(
      initialPosition.x,
      initialPosition.y + (shiftedUp ? shiftAmount : 0.0f),
      initialPosition.z + (shiftedRight ? shiftAmount : 0.0f) + (shiftedLeft ? -shiftAmount : 0.0f)
    );
	}

  void RandomizePosition() {
    if (rng.NextDouble() < shiftChance) { 
      shiftedUp = !shiftedUp;
    }
    if (2*rng.NextDouble() < shiftChance) { 
      shiftedLeft = !shiftedLeft;
    }
    if (2*rng.NextDouble() < shiftChance) { 
      shiftedRight = !shiftedRight;
    }
  }
}
