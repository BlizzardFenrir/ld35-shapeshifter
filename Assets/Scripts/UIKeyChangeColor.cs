using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIKeyChangeColor : MonoBehaviour {
  public Color heldColor;
  public Color releasedColor;
  public string key;

  private Image img;
  // Use this for initialization
  void Start () {
    img = GetComponent<Image>();
  }
  
  // Update is called once per frame
  void Update () {
    if (Input.GetKey(key)) {
      img.color = heldColor;
    } else {
      img.color = releasedColor;
    }
  }
}
