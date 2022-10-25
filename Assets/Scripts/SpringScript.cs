using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpringScript : MonoBehaviour {
    public float power;
    public float maxPower = 1000f;
    public Slider powerSlider;
    private List<Rigidbody> ballList;
    private bool flage=false;

    // Use this for initialization
    void Start () {
        powerSlider.minValue = 1f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();


    }
	
	// Update is called once per frame
	void Update () {
        if(flage) powerSlider.value = power;
        if(ballList.Count>0){
           
            if(Input.GetKey(KeyCode.Space)){
                if (power < maxPower)
                    power += 5 + Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach(Rigidbody r in ballList){
                    r.AddForce(power * Vector3.forward);
                   
                }
            }
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball")){
               ballList.Add(other.gameObject.GetComponent<Rigidbody>());
            flage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
                power = 1f;
        powerSlider.value = 0;
        flage = false;
    }
}
