using UnityEngine;
using System.Collections;

public delegate void ResetStage();

public class ResetEvent : MonoBehaviour {
  public static event ResetStage OnResetStage;

	void Update () {
    if (transform.position.z < -10) {
      if (OnResetStage != null) {
        OnResetStage();
      }        
    }
	}
}
