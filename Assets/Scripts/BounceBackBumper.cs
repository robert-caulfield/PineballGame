using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BounceBackBumper : MonoBehaviour
{
    public float bounceForce;
    public float scoreValue = 100f;
    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            collision.rigidbody.AddExplosionForce(
                bounceForce,
                collision.contacts[0].point, 15);

             GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            await Task.Delay(200);
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");



        }
    }
}
