using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TweenKeypresses : MonoBehaviour {
    class TweenState {
        public bool pressed = false;
        public float changeTime = 0.0f;
        public float valueWhenChanged = 0.0f;
    }

    private Dictionary<char, TweenState> states;

    public static char[] keys = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

	// Use this for initialization
	void Start () {
        states = new Dictionary<char, TweenState>();

        foreach (char key in keys) {
            states[key] = new TweenState();
        }
	}
	
	// Update is called once per frame
	void Update () {
    bool playSfx = false;

    foreach (char key in keys) {
      var state = states[key];

      if (Input.GetKey(new string(key, 1))) {
        if (!state.pressed) {
          state.valueWhenChanged = ScaleFactor(key);
          state.pressed = true;
          state.changeTime = Time.time;
          playSfx = true;
        }
      } else {
        if (state.pressed) {
          state.valueWhenChanged = ScaleFactor(key);
          state.pressed = false;
          state.changeTime = Time.time;
        }
      }
    }

    if (playSfx) {
      GetComponent<AudioSource>().Play();
    }
	}

    public virtual List<char> PressedKeys() {
      List<char> result = new List<char>();

      foreach (var state in states) {
        if (state.Value.pressed) {
          result.Add(state.Key);
        }
      }

      return result;
    }

    public virtual float ScaleFactor(char key) {
        TweenState state = states[key];
        float deltaTime = Time.time - state.changeTime;
        float animationLength = 0.5f;
        float eased;

        deltaTime = Mathf.Clamp(deltaTime, 0, animationLength);

        if (state.pressed) {
            eased = EasingFunctions.EaseOutElastic(deltaTime, 0, 1, animationLength);
            return Mathf.Clamp(state.valueWhenChanged + eased, 0, 1);
        } else {
            eased = EasingFunctions.EaseOutElastic(deltaTime, 0, 1, animationLength);
            return Mathf.Clamp(state.valueWhenChanged - eased, 0, 1);
        }

    }
}
