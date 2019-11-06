using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    // Store sound effect for whenever ball lands
    public AudioSource Bounce;

    // Store sound effect for whenever ball hits domino
    public AudioSource DominoHit;

    // Store sound effect for whenever ball hits domino
    public AudioSource TrophyWin;

    private void OnTriggerEnter(Collider other)
    {
        //TODO When entering a Collider, set that object inactive if it has a tag called "PickUp"
        if (other.gameObject.CompareTag("PickUp"))
        {
            TrophyWin.Play();
            other.gameObject.SetActive(false);
        }
        Bounce.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "StartSlopeCube")
        {
            Bounce.Play();
        }

        if (collision.gameObject.CompareTag("Domino"))
        {
            Debug.Log("Playing audio now");
            DominoHit.Play();
        }
    }
}
