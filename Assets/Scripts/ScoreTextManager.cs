using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour {
    public Text scoretext;
    private float time;
    public int score;
    public GameObject unityChan;
    public UnityChanManager unityChanManager;
    // Use this for initialization
    void Start () {
        unityChanManager = unityChan.GetComponent<UnityChanManager>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (unityChanManager.isDeath == false) {
            time -= Time.deltaTime;
            if (time <= 0.0f) {
                time = 0.01f;

                scoretext.text = ("" + score);
                score++;
            }
        }
	}
}
