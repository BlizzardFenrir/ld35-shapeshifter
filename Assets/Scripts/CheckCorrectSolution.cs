using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CheckCorrectSolution : MonoBehaviour {
  public TweenKeypresses currentKeypresses;
  public RandomKeypresses desiredKeypresses;
  public List<ChangeLightColor> lights;

  void Start() {
  }

  void Update() {
    var correct = false;

    var a = currentKeypresses.PressedKeys().OrderBy(t => t);
    var b = desiredKeypresses.PressedKeys().OrderBy(t => t);

    if (Enumerable.SequenceEqual(a, b)) {
      correct = true;
    }

    foreach (var light in lights) {
      light.state = correct;
    }
  }
}
