using UnityEngine;
using System.Collections;

public class AudienceMemberMovement : MonoBehaviour {
  public float shiftAmount = 0.2f;
  public double shiftChance = 0.05;

  private bool shiftedUp = false;
  private bool shiftedLeft = false;
  private bool shiftedRight = false;
  private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
    initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    RandomizePosition();

    transform.position = new Vector3(
      transform.position.x,
      transform.position.y,
      initialPosition.z + (shiftedRight ? shiftAmount : 0.0f) + (shiftedLeft ? -shiftAmount : 0.0f)
    );
	}

  void RandomizePosition() {
    if (Random.value < shiftChance) { 
      shiftedUp = !shiftedUp;
    }
    if (2*Random.value < shiftChance) { 
      shiftedLeft = !shiftedLeft;
    }
    if (2*Random.value < shiftChance) { 
      shiftedRight = !shiftedRight;
    }
  }
}
