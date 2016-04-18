using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
  private AudioSource asource;
  private bool startedPlaying = false;

  // Use this for initialization
  void Awake () {
    asource = GetComponent<AudioSource>();
  }

  void Start() {
    asource.Play();
    startedPlaying = true;
  }
  
  // Update is called once per frame
  void Update () {
    if (startedPlaying && !asource.isPlaying) {
      Destroy(gameObject);
    }
  }
}
