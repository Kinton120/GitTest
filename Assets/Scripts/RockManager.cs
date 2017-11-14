using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {
    public GameObject rock;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        rock = GameObject.Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(this);
    }
}
