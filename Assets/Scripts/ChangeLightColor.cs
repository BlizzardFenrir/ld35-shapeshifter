using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeLightColor : MonoBehaviour {
  public bool state;
  public List<Light> lights;

  private AlarmLightRotate rotator;

	// Use this for initialization
	void Start () {
    rotator = this.GetComponent<AlarmLightRotate> ();
	}
	
	// Update is called once per frame
	void Update () {
    rotator.rotating = !state;

	  if (state) {
        foreach (var light in lights) {
          light.color = new Color(0, 1, 0);
        }
      } else {
        foreach (var light in lights) {
          light.color = new Color(1, 0, 0);
        }
      }
	}
}
