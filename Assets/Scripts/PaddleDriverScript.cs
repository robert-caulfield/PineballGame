using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDriverScript : MonoBehaviour {

    public float hitPower = 1000f;
    public float paddleDamper = 10f;
    public float upPosition = 45f;
    public float downPosition = 0f;

    public HingeJoint hinge;
    public string inputName;

    public AudioClip activateSound;
    public AudioClip deactivateSound;

    AudioSource audioplayer;

    // Use this for initialization
    void Start () {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
		audioplayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring
        {
            spring = hitPower,
            damper = paddleDamper
        };
        spring.targetPosition =Input.GetKey(KeyCode.Space) ? upPosition : downPosition;
        hinge.spring = spring;
        hinge.useLimits = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioplayer.PlayOneShot(activateSound);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioplayer.PlayOneShot(deactivateSound);
        }

	}
}
