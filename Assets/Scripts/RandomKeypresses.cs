using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class RandomKeypresses : TweenKeypresses {

    public int difficulty;
    private Dictionary<char, bool> states;

    void Start () {
      states = new Dictionary<char, bool>();

      VertexTransform vt = GetComponent<VertexTransform>();
      List<char> keys = new List<char>();
      foreach (TransformMesh tm in vt.transformMeshes) {
        keys.Add(tm.Key);
        states[tm.Key] = false;
      }

      System.Random rand = new System.Random();
      List<char> pressedKeys = keys.OrderBy(c => rand.Next()).Take(difficulty).ToList();
      foreach (char k in pressedKeys) {
        states[k] = true;
      }
    }
    
    void Update () {

    }

    public override float ScaleFactor(char key) {
      return states[key] ? 1.0f : 0.0f;
    }
}
