using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  public GameObject mainMenu;
  public WallMove wall;
  public RandomKeypresses wallShape;

  private bool onMainMenu;
  
  void Start() {
    onMainMenu = true;
  }

  // Update is called once per frame
  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      if (onMainMenu) {
        QuitGame();
      } else {
        BackToMainMenu();
      }
    }

    if (onMainMenu && Input.GetKeyDown(KeyCode.Return)) {
      StartPlaying();
    }
  }

  public void BackToMainMenu() {
    wall.ResetWall();

    wall.paused = true;
    mainMenu.SetActive(true);
    onMainMenu = true;
  }

  public void StartPlaying() {
    wall.ResetWall();
    wallShape.Randomize();

    wall.paused = false;
    mainMenu.SetActive(false);
    onMainMenu = false;
  }

  public void QuitGame() {
    Debug.Log("Quit game");
    Application.Quit();
  }
}
