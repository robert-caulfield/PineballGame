using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

using TMPro;

public class BallSurface : MonoBehaviour
{
    public GameObject floor;
    public float score = 0;
    public TMP_Text displayTxt; 

    Rigidbody rb;
    AudioSource audioplayer;

    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0, 0.1f);
        rb = GetComponent<Rigidbody>();

        if(floor == null)
        {
            floor = GameObject.FindGameObjectWithTag("Floor");
        }

        if (displayTxt == null)
        {
            displayTxt = GameObject.FindGameObjectWithTag("ScoreDisplay").GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.position.Set(0,
            floor.transform.position.y + 0.17501f
            , 0);

        /*transform.position.Set(0,
            floor.transform.position.y + 0.17501f
            , 0);
        */
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BounceBackBumper>())
        {
            score += collision.gameObject.GetComponent<BounceBackBumper>().scoreValue;
            audioplayer.Play();

        }
        displayTxt.text = "Score: " + (GameManager.instance.current_score + score);

    }
}
