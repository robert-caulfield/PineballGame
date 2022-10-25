using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DZscript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != null && collision.GetComponent<Rigidbody>().CompareTag("Ball"))
        {
            BallSurface ball = collision.gameObject.GetComponent<BallSurface>();
            float score = ball ? ball.score : 0;
            Destroy(collision.gameObject);
            
            GameManager.instance.SubtractBall(score);
            
        }
    }

}
