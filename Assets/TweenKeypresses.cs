using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TweenKeypresses : MonoBehaviour {
    public Dictionary<char, float> keyStates;

    char[] keys = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

	// Use this for initialization
	void Start () {
        keyStates = new Dictionary<char, float>();

        foreach (char key in keys) {
            keyStates[key] = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (char key in keys) {
            if (Input.GetKey(new string(key, 1))) {
                keyStates[key] = Mathf.Clamp(keyStates[key] + 0.05f, 0.0f, 1.0f);
            } else {
                keyStates[key] = Mathf.Clamp(keyStates[key] - 0.05f, 0.0f, 1.0f);
            }

            Debug.Log(key);
            Debug.Log(keyStates[key]);
        }
	}
}
