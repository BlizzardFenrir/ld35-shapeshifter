using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void NoMoreAttempts();

public class ScoreManager : MonoBehaviour {
  public static event NoMoreAttempts OnNoAttemptsLeft;

  public int score;
  public int highscore;
  public int attemptsLeft;

  public int baseDifficulty;

  private int maxDifficulty;

  public RandomKeypresses keypresses;
  public List<int> difficultyThresholds;

  void OnEnable() {
    WinLoseEvent.OnWinStage += WinPoint;
    WinLoseEvent.OnLoseStage += LoseAttempt;
  }

  void OnDisable() {
    WinLoseEvent.OnWinStage -= WinPoint;
    WinLoseEvent.OnLoseStage -= LoseAttempt;
  }

  // Use this for initialization
  void Start () {
    score = 0;
    highscore = 0;
    attemptsLeft = 0;
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

  public void LoseAttempt() {
    attemptsLeft -= 1;
    if (attemptsLeft <= 0) {
      if (OnNoAttemptsLeft != null) {
        Debug.Log("No attempts left.");
        OnNoAttemptsLeft();
      }
    }
  }

  public void WinPoint() {
    attemptsLeft = 5;
    score += 1;
    highscore = Mathf.Max(score, highscore);
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
