using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class RandomKeypresses : TweenKeypresses {

    public int difficulty;
    public List< string > forbiddenCombinations;
    private Dictionary<char, bool> states;
    System.Random rand;

    void Awake () {
      states = new Dictionary<char, bool>();
      rand = new System.Random();

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
      int randomizationAttempts = 3;

      while (randomizationAttempts > 0) {
        // Reset
        List<char> keys = new List<char>(states.Keys);
        foreach (char key in keys) {
          states[key] = false;
        }

        // Randomize
        List<char> pressedKeys = keys.OrderBy(c => rand.Next()).Take(difficulty).ToList();
        foreach (char k in pressedKeys) {
          states[k] = true;
        }
        // Debug.Log("Attempts: " + randomizationAttempts + ", " + getShapeLetters() );

        // Verify forbidden combinations
        bool passedTests = true;
        foreach (string combination in forbiddenCombinations) {
          if (!combination.Except(pressedKeys).Any()) {
            // Matched a forbidden combination
            // Debug.Log("Found forbidden combination: " + combination);
            passedTests = false;
          }
        }
        if (!passedTests) {
          randomizationAttempts -= 1;
        } else {
          randomizationAttempts = 0;
        }
      }

      // Correctly randomized
      // Debug.Log("Good randomization: " + getShapeLetters() );
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

    public void increaseDifficulty() {
      difficulty = Mathf.Clamp(difficulty + 1, 0, 10);
    }

    public void lowerDifficulty() {
      difficulty = Mathf.Clamp(difficulty - 1, 0, 10);
    }
}
