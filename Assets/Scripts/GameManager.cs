using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject rock;
    private float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0.0f) {
            time = 3.0f;
            Instantiate(rock, new Vector3(Random.Range(-2.3f,2.3f), 10, 0), Quaternion.identity);
        }
	}
}
