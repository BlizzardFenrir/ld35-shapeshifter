using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CheckCorrectSolution : MonoBehaviour {
  public TweenKeypresses currentKeypresses;
  public RandomKeypresses desiredKeypresses;
  public List<ChangeLightColor> lights;

  public PlaySound correctSound;
  private bool wasCorrect;

  void Start() {
    wasCorrect = false;
  }

  void Update() {
    var correct = IsCorrect(currentKeypresses, desiredKeypresses);

    // Play sound when player shapes becomes correct
    if (wasCorrect != correct && correct) {
      Instantiate(correctSound, transform.position, Quaternion.identity);
    }
    wasCorrect = correct;

    // Change light state if player shape is correct
    foreach (var light in lights) {
      light.state = correct;
    }
  }

  public static bool IsCorrect(TweenKeypresses current, RandomKeypresses desired) {
    var a = current.PressedKeys().OrderBy(t => t);
    var b = desired.PressedKeys().OrderBy(t => t);

    return Enumerable.SequenceEqual(a, b);
  }
}
