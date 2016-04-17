using UnityEngine;
using System.Collections;

public class ApplaudOnWin : MonoBehaviour {

  void OnEnable() {
    WinLoseEvent.OnWinStage += Applaud;
  }

  void OnDisable() {
    WinLoseEvent.OnWinStage -= Applaud;
  }

	void Start () {
	}
	
	void Update () {
	}

  void Applaud() {
    GetComponent<AudioSource>().Play();
  }
    
}
