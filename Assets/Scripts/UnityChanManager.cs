using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanManager : MonoBehaviour {

    private Animator animator;      //ユニティちゃんの動作
    public bool isRightRunning;     //右向きに走っているか
    public bool isLeftRunning;      //左向きに走っているか
    public bool isBothButton;       //左右のボタンがどちらも押されているか
    public bool isRightSameTap;    //左右どちらかのボタンを二重で押されているか
    public bool isLeftSameTap;
    public float speed = 0.05f;     //ユニティちゃんのスピード
    public GameObject textGameOver;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //左右のボタンがどちらも押されていたとき
        if (isRightRunning && isLeftRunning) {
            animator.SetBool("is_running", false);
            isRightRunning = false;
            isLeftRunning = false;
            isBothButton = true;
        } else
        //左右のボタンのどちらかが押されているとき
        if (isRightRunning || isLeftRunning) {
            animator.SetBool("is_running", true);
            Vector3 pos = transform.position;
            if (isRightRunning) {
                pos.x -= speed;
            } else {
                pos.x += speed;
            }
            if (pos.x >= 2.3f) {
                pos.x = 2.3f;
            }
            if (pos.x <= -2.3f) {
                pos.x = -2.3f;
            }
            transform.position = pos;
        }
    }

    //右のボタンを押したとき
    public void PushButtonRightDown() {
        if (isBothButton == false) {
            if (isRightRunning == false) {
                transform.Rotate(0, -90, 0);
                isRightRunning = true;
            } else {
                isRightSameTap = true;
            }
        }
    }
    //右のボタンを離したとき
    public void PushButtonRightUp() {
        if (isBothButton) {
            if (isLeftRunning == false) {
                transform.Rotate(0, 90, 0);
            }
            isLeftRunning = true;
            isBothButton = false;
        } else {
            animator.SetBool("is_running", false);
            if (isRightRunning && isRightSameTap == false) {
                transform.Rotate(0, 90, 0);
            }
            if (isRightSameTap) {
                isRightSameTap = false;
            } else {
                isRightRunning = false;
            }
            
        }
    }

    //左のボタンを押したとき
    public void PushButtonLeftDown() {
        if (isBothButton == false) {
            if (isLeftRunning == false) {
                transform.Rotate(0, 90, 0);
                isLeftRunning = true;
            } else {
                isLeftSameTap = true;
            }
        }
    }
    //左のボタンを離したとき
    public void PushButtonLeftUp() {
        if (isBothButton) {
            if (isRightRunning == false) {
                transform.Rotate(0, -90, 0);
            }
            isRightRunning = true;
            isBothButton = false;
        } else {
            animator.SetBool("is_running", false);
            if (isLeftRunning && isLeftSameTap == false) {
                transform.Rotate(0, -90, 0);
            }
            if (isLeftSameTap) {
                isLeftSameTap = false;
            } else {
                isLeftRunning = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Rock") {
            textGameOver.SetActive(true);
        }
    }
}
