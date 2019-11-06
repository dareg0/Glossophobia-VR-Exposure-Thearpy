using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Store audio source for mouse click
    public AudioSource Mouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCartoon()
    {
        Mouse.Play();
        SceneManager.LoadScene("Demo_1");
    }

    public void PlaySciFi()
    {
        Mouse.Play();
        SceneManager.LoadScene("Demo_SciFi_1");
    }
}
