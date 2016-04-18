using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {
  public GameObject mainMenuUI;
  public GameObject gameUI;
  public ScoreManager scoreManager;
  public UIGameOverText gameOverText;
  public WallMove wall;
  public GameObject player;
  public RandomKeypresses wallShape;

  private bool onMainMenu;
  private bool gameOver;
  
  void Start() {
    onMainMenu = true;
    mainMenuUI.SetActive(true);
    gameUI.SetActive(false);
  }

  void OnEnable() {
    ScoreManager.OnNoAttemptsLeft += GameOver;
  }

  void OnDisable() {
    ScoreManager.OnNoAttemptsLeft -= GameOver;
  }

  // Update is called once per frame
  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      if (onMainMenu) {
        QuitGame();
      } else {
        BackToMainMenu();
        gameOverText.HideGameOverMessage();
      }
    }

    if (onMainMenu && Input.GetKeyDown(KeyCode.Return)) {
      StartPlaying();
    }
  }

  public void GameOver() {
    wall.paused = true;

    gameOverText.ShowGameOverMessage();
  }

  public void BackToMainMenu() {
    player.GetComponent<ThrowOffPlatform>().OnResetStage();
    wall.ResetWall();
    scoreManager.ResetScore();
    scoreManager.ResetAttempts();

    wall.paused = true;
    mainMenuUI.SetActive(true);
    gameUI.SetActive(false);
    onMainMenu = true;
  }

  public void StartPlaying() {
    player.GetComponent<ThrowOffPlatform>().OnResetStage();
    wall.ResetWall();
    wallShape.Randomize();
    scoreManager.ResetScore();
    scoreManager.ResetAttempts();

    wall.paused = false;
    mainMenuUI.SetActive(false);
    gameUI.SetActive(true);
    onMainMenu = false;
  }

  public void QuitGame() {
    Application.Quit();
  }
}
