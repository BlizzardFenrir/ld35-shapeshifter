using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISetDifficultyText : MonoBehaviour {
  public RandomKeypresses rk;

  [HideInInspector][System.NonSerialized]
  private Text t;

  void Awake() {
    t = GetComponent<Text>();
  }

  void Update () {
    if (rk != null && t != null) t.text = "Difficulty: " + rk.difficulty;
  }
}
