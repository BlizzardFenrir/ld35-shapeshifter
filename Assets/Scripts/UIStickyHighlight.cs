using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStickyHighlight : MonoBehaviour {
  public Color heldColor;
  public Color releasedColor;
  public TweenKeypresses keypresses;

  private Image img;
  // Use this for initialization
  void Start () {
    img = GetComponent<Image>();
  }
  
  // Update is called once per frame
  void Update () {
    if (keypresses.stickyKeys) {
      img.color = heldColor;
    } else {
      img.color = releasedColor;
    }
  }
}
