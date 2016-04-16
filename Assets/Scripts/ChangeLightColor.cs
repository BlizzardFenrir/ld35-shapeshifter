using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeLightColor : MonoBehaviour {
  public bool state;
  public List<Light> lights;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
