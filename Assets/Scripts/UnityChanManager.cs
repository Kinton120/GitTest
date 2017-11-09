using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanManager : MonoBehaviour {

    private Animator animator;
    public bool isRightRunning;
    public bool isLeftRunning;
    public bool isBothButton;
    public bool isSameTapButton;
    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (isRightRunning && isLeftRunning) {
            animator.SetBool("is_running", false);
            isRightRunning = false;
            isLeftRunning = false;
            isBothButton = true;
        }
        if (isRightRunning || isLeftRunning) {
            animator.SetBool("is_running", true);
            Vector3 pos = transform.position;
            if (isRightRunning) {
                pos.x -= 0.05f;
            } else {
                pos.x += 0.05f;
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

    public void PushButtonRightDown() {
        if (isRightRunning && isLeftRunning) {
            
        } else {
            if (isRightRunning == false) {
                transform.Rotate(0, -90, 0);
                isRightRunning = true;
            } else {
                isSameTapButton = true;
            }
        }
    }
    public void PushButtonRightUp() {
        if (isRightRunning == false && isLeftRunning == false && isBothButton) {

            if (isLeftRunning == false) {
                transform.Rotate(0, 90, 0);
            }
            isLeftRunning = true;
            isBothButton = false;
        } else {
            animator.SetBool("is_running", false);
            if (isRightRunning && isSameTapButton == false) {
                transform.Rotate(0, 90, 0);
            }
            if (isSameTapButton) {
                isSameTapButton = false;
            } else {
                isRightRunning = false;
            }
            
        }
    }

    public void PushButtonLeftDown() {
        if (isRightRunning && isLeftRunning) {
                
        } else {
            if (isLeftRunning == false) {
                transform.Rotate(0, 90, 0);
                isLeftRunning = true;
            } else {
                isSameTapButton = true;
            }
        }
    }
    public void PushButtonLeftUp() {
        if (isRightRunning == false && isLeftRunning == false && isBothButton) {
            if (isRightRunning == false) {
                transform.Rotate(0, -90, 0);
            }
            isRightRunning = true;
            isBothButton = false;
        } else {
            animator.SetBool("is_running", false);
            if (isLeftRunning && isSameTapButton == false) {
                transform.Rotate(0, -90, 0);
            }
            if (isSameTapButton) {
                isSameTapButton = false;
            } else {
                isLeftRunning = false;
            }
        }
    }
}
