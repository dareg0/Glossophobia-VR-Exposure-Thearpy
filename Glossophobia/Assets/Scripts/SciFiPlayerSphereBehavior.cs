using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SciFiPlayerSphereBehavior : MonoBehaviour
{
    // Store sound effect for whenever ball lands
    public AudioSource Bounce;

    // Store sound effect for whenever ball hits trophy
    public AudioSource Trophy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the player sphere falls below -40 on the y axis, restart the scene
        if (gameObject.transform.position.y <= -40)
        {
            LoadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When entering a Collider, set that object inactive if it has a tag called "PickUp"
        if (other.gameObject.CompareTag("PickUp"))
        {
            Trophy.Play();
            other.gameObject.SetActive(false);
            Invoke("LoadMenu", 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PointAPlatform" || collision.gameObject.name == "PointBPlatform" || collision.gameObject.name == "PointCPlatform" || collision.gameObject.name == "PointDPlatform" || collision.gameObject.name == "Bridge")
        {
            Bounce.Play();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Demo_SciFi_2");
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Demo_0_MainMenu");
    }
}
