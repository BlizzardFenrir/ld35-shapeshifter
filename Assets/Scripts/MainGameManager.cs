using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour {
  public GameObject mainMenuUI;
  public GameObject gameUI;
  public ScoreManager scoreManager;
  public UIGameOverText gameOverText;
  public WallMove wall;
  public RandomKeypresses wallShape;

  private bool onMainMenu;
  private bool gameOver;
  
  void Start() {
    onMainMenu = true;
    mainMenuUI.SetActive(true);
    gameUI.SetActive(false);
  }

  void Enable() {
    ScoreManager.OnNoAttemptsLeft += GameOver;
  }

  void Disable() {
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
    Debug.Log("GameOver");
    wall.ResetWall();
    scoreManager.ResetScore();
    wall.paused = true;

    gameOverText.ShowGameOverMessage();
  }

  public void BackToMainMenu() {
    wall.ResetWall();
    scoreManager.ResetScore();

    wall.paused = true;
    mainMenuUI.SetActive(true);
    gameUI.SetActive(false);
    onMainMenu = true;
  }

  public void StartPlaying() {
    wall.ResetWall();
    wallShape.Randomize();

    wall.paused = false;
    mainMenuUI.SetActive(false);
    gameUI.SetActive(true);
    onMainMenu = false;
  }

  public void QuitGame() {
    Debug.Log("Quit game");
    Application.Quit();
  }
}
