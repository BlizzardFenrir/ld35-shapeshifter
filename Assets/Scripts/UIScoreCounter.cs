using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScoreCounter : MonoBehaviour {

  public ScoreManager scoreManager;
  private Text textComponent;

  // Use this for initialization
  void Awake () {
    textComponent = GetComponent<Text>();
  }
  
  // Update is called once per frame
  void Update () {
    textComponent.text = "Score: " + scoreManager.score;
  }
}
