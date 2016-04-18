using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameOverText : MonoBehaviour {
  public MainGameManager gm;
  private Text textComponent;
  private Outline outlineComponent;
  private Color initialTextColor;
  private Color initialOutlineColor;
  private float alpha;

  // Use this for initialization
  void Awake () {
    textComponent = GetComponent<Text>();
    outlineComponent = GetComponent<Outline>();
  }

  void Start() {
    initialTextColor = textComponent.color;
    initialOutlineColor = outlineComponent.effectColor;
  }
  
  // Update is called once per frame
  void Update () {
    alpha = Mathf.Max(alpha - 1.0f * Time.deltaTime, 0.0f);
    textComponent.color = new Color(initialTextColor.r,
                                    initialTextColor.g,
                                    initialTextColor.b,
                                    initialTextColor.a * Mathf.Clamp(alpha, 0.0f, 1.0f));
    outlineComponent.effectColor = new Color(initialOutlineColor.r,
                                             initialOutlineColor.g,
                                             initialOutlineColor.b,
                                             initialOutlineColor.a * Mathf.Clamp(alpha, 0.0f, 1.0f));

    if (alpha <= 0) {
      gm.BackToMainMenu();
    }
  }

  public void ShowGameOverMessage() {
    alpha = 5.0f;
    gameObject.SetActive(true);
    textComponent.color = initialTextColor;
    outlineComponent.effectColor = initialOutlineColor;
  }

  public void HideGameOverMessage() {
    alpha = 0.0f;
    gameObject.SetActive(false);
  }
}
