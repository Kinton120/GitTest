using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {
    public GameObject exploadObj;
    public GameObject exploadPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(90, 90, 90) * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision) {
        Instantiate(exploadObj, exploadPos.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
