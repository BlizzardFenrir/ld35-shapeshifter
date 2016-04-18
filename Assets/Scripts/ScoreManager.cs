using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {
  public int score;

  public int baseDifficulty;

  private int maxDifficulty;

  public RandomKeypresses keypresses;
  public List<int> difficultyThresholds;

  void OnEnable() {
    WinLoseEvent.OnWinStage += WinPoint;
  }

  void OnDisable() {
    WinLoseEvent.OnWinStage -= WinPoint;
  }

  // Use this for initialization
  void Start () {
    score = 0;
    baseDifficulty = 0;
    maxDifficulty = difficultyThresholds.Count;
  }
  
  // Update is called once per frame
  void Update () {
  
  }

  public void IncBaseDifficulty() {
    baseDifficulty = Mathf.Clamp(baseDifficulty + 1, 0, maxDifficulty);
    RecalculateDifficulty();
  }

  public void DecBaseDifficulty() {
    baseDifficulty = Mathf.Clamp(baseDifficulty - 1, 0, maxDifficulty);
    RecalculateDifficulty();
  }  

  public void ResetScore() {
    score = 0;
  }

  public void WinPoint() {
    score += 1;
    RecalculateDifficulty();
  }

  public void RecalculateDifficulty() {
    int difficultyBonus = baseDifficulty;
    foreach (int thresh in difficultyThresholds) {
      if (score >= thresh) difficultyBonus += 1;
    }
    keypresses.difficulty = 1 + Mathf.Clamp(difficultyBonus, 0, maxDifficulty);
  }
}
