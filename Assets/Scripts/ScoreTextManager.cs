using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour {
    public Text scoretext;
    private float time;
    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0.0) {
            time = 0.01f;

            scoretext.text = ("" + score);
            score++;
        }
	}
}
