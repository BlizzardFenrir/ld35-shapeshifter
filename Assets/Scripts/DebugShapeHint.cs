using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugShapeHint : MonoBehaviour {
  public RandomKeypresses shapegenerator;

  [HideInInspector][System.NonSerialized]
  private Text textComponent;

  // Use this for initialization
  void Awake () {
    textComponent = GetComponent<Text>();
  }
  
  // Update is called once per frame
  void Update () {
    if (shapegenerator != null) textComponent.text = "Solution: " + shapegenerator.getShapeLetters();
  }
}
