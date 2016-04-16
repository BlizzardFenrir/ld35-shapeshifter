using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class RandomKeypresses : TweenKeypresses {

    public int difficulty;
    private Dictionary<char, bool> states;

    void Awake () {
      states = new Dictionary<char, bool>();

      VertexTransform vt = GetComponent<VertexTransform>();
      List<char> keys = new List<char>();
      foreach (TransformMesh tm in vt.transformMeshes) {
        keys.Add(tm.Key);
        states[tm.Key] = false;
      }
    }

    void Start() {
      Randomize();
    }

    public void Randomize() {
      // Reset
      List<char> keys = new List<char>(states.Keys);
      foreach (char key in keys) {
        states[key] = false;
      }

      // Randomize
      System.Random rand = new System.Random();
      List<char> pressedKeys = keys.OrderBy(c => rand.Next()).Take(difficulty).ToList();
      foreach (char k in pressedKeys) {
        states[k] = true;
      }
    }
    
    void Update () {
    }

    public List<char> PressedKeys() {
      List<char> result = new List<char>();

      foreach (var state in states) {
        if (state.Value) {
          result.Add(state.Key);
        }
      }

      return result;
    }

    public override float ScaleFactor(char key) {
      return states[key] ? 1.0f : 0.0f;
    }

    public string getShapeLetters() {
      string result = "";
      foreach (KeyValuePair<char, bool> kvp in states) {
        if (kvp.Value) result += kvp.Key;
      }
      return result;
    }
}
