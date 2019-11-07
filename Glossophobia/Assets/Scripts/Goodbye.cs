using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goodbye : MonoBehaviour
{
    // Store whether domino and player cube have collided
    bool alreadyCollided;

    // Store sound effect for whenever domino hits cube
    public AudioSource CubeHit;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // If domino and cube have collided, wait for 4 seconds then load Demo_2
        if (alreadyCollided)
        {
            //Debug.Log("Starting countdown");
            Invoke("LoadScene", 4);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Domino"))
        {
            //Debug.Log("Collided");
            alreadyCollided = true;
            CubeHit.Play();
        }
    }

    // Load Demo_2
    void LoadScene()
    {
        SceneManager.LoadScene("Demo_2");
    }
}
