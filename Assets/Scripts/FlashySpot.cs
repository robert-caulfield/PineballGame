using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashySpot : MonoBehaviour
{
    private int count = 0;
    public GameObject shineLight;

    void FixedUpdate()
    {
        count++;

        if (count < 20)
            shineLight.SetActive(true);
        else if (count >= 20 && count < 40)
            shineLight.SetActive(false);
        else
            count = 0;
    }
}
