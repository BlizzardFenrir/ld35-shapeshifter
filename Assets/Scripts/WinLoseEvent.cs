using UnityEngine;
using System.Collections;

public delegate void WinStage();
public delegate void LoseStage();

public class WinLoseEvent : MonoBehaviour {
  public static event WinStage OnWinStage;
  public static event LoseStage OnLoseStage;

  public GameObject player;
  public GameObject wall;

  public TweenKeypresses current;
  public RandomKeypresses desired;

  private bool triggered = false;
  private float initialPlayerZ;

  void OnEnable() {
    ResetEvent.OnResetStage += OnResetStage;
  }

  void OnDisable() {
    ResetEvent.OnResetStage -= OnResetStage;
  }

	void Start () {
    initialPlayerZ = player.transform.position.z;
	}
	
	void Update () {
    if (triggered) {
      return;
    }

    if (wall.transform.position.z < initialPlayerZ) {
      triggered = true;

      if (CheckCorrectSolution.IsCorrect(current, desired)) {
        if (OnWinStage != null) {
          OnWinStage();
        }
      } else {
        if (OnLoseStage != null) {
          OnLoseStage();
        }
      }
    }
	}

  void OnResetStage() {
    triggered = false;
  }
}
