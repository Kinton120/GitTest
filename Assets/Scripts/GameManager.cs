using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject rock;
    private float time;
    private float changeTime;
    public Rigidbody rockBody;
    public GameObject textScore;
    public ScoreTextManager scoreTextManager;
    public GameObject unityChan;
    public UnityChanManager unityChanManager;
    public GameObject textGameOver;
    public GameObject canvasButton;
    public GameObject buttonGoTitle;
	// Use this for initialization
	void Start () {
        scoreTextManager = textScore.GetComponent<ScoreTextManager>();
        unityChanManager = unityChan.GetComponent<UnityChanManager>();
        changeTime = 0.0f;
        rockBody.drag = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (unityChanManager.isDeath == false) {
            time -= Time.deltaTime;
            if (time <= 0.0f) {
                time = 3.0f - changeTime - Random.Range(-1.0f, 1.0f);
                if (time < 0.1f) {
                    time = 0.2f;
                }
                Instantiate(rock, new Vector3(Random.Range(-2.3f, 2.3f), 15, 0), Quaternion.identity);
            }
            if (scoreTextManager.score != 0 && (scoreTextManager.score % 1000) == 0 && (scoreTextManager.score % 2000) != 0) {
                if (rockBody.drag > 0.0f) {
                    rockBody.drag -= 0.1f;
                }
            }
            if (scoreTextManager.score != 0 && (scoreTextManager.score % 2000) == 0) {
                if (time > 0.2f) {
                    changeTime += 0.2f;
                }
            }
        } else {
            textGameOver.SetActive(true);
            unityChanManager.animator.SetBool("is_death", true);
            canvasButton.SetActive(false);
            buttonGoTitle.SetActive(true);
        }
	}

    public void PushButtonGoTitle() {
        SceneManager.LoadScene("TitleScene");
    }
}
