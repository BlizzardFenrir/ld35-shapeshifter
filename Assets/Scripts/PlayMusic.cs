using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayMusic : MonoBehaviour {
  public List<AudioClip> songs;

  [HideInInspector][System.NonSerialized]
  private AudioSource audioPlayer;
  private int nowPlaying;

  // Use this for initialization
  void Start () {
    audioPlayer = GetComponent<AudioSource>();
    nowPlaying = -1;
  }
  
  // Update is called once per frame
  void Update () {
    if (!audioPlayer.isPlaying)
      playNextSong();
  }

  public void playNextSong() {
    if (songs.Count > 0) {
      nowPlaying = (nowPlaying + 1) % songs.Count;
      audioPlayer.clip = songs[nowPlaying];
      audioPlayer.Play();
    }
  }
}
