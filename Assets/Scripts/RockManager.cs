using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {
    public GameObject exploadObj;
    public GameObject exploadPos;
    public float x, y, z;
	// Use this for initialization
	void Start () {
        x = Random.Range(-360, 360);
        y = Random.Range(-360, 360);
        z = Random.Range(-360, 360);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(z,y,z) * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Plane") {
            Instantiate(exploadObj, exploadPos.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
