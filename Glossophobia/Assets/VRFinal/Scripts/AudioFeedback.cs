﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class AudioFeedback : MonoBehaviour
{
    //A boolean that flags whether there's a connected microphone  
    private bool micConnected = false;

    //The maximum and minimum available recording frequencies  
    private int minFreq;
    private int maxFreq;

    //A handle to the attached AudioSource  
    private AudioSource goAudioSource;

	public GameObject audioButton;

    private void Awake()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Check if there is at least one microphone connected  
        if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
        else //At least one microphone is present  
        {
            //Set 'micConnected' to true  
            micConnected = true;
            Debug.Log("WHEEEEEEEHEEEEEEEEEEEEEHHHOOOOOOOO");

            //Get the default microphone recording capabilities  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...  
            if (minFreq == 0 && maxFreq == 0)
            {
                //...meaning 44100 Hz can be used as the recording sampling rate  
                maxFreq = 44100;
            }

            //Get the attached AudioSource component  
            goAudioSource = this.GetComponent<AudioSource>();
        }
        //foreach (var device in Microphone.devices)
        //{
        //    Debug.Log("Name: " + device);
        //}
    }

    //void OnGUI()
    //{
    //    //If there is a microphone  
    //    if (micConnected)
    //    {
    //        //If the audio from any microphone isn't being captured  
    //        if (!Microphone.IsRecording(null))
    //        {
    //            //Case the 'Record' button gets pressed  
    //            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Record"))
    //            {
    //                //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource  
    //                //goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);


    //                goAudioSource.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
    //                //goAudioSource.loop = true;
    //                while (!(Microphone.GetPosition(null) > 0)) { }
    //                goAudioSource.Play();

    //                Debug.Log("I'm here");
    //                audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Audio";
    //            }
    //        }

    //        else //Recording is in progress  
    //        {
    //            //Case the 'Stop and Play' button gets pressed  
    //            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Stop and Play!"))
    //            {
    //                Microphone.End(null); //Stop the audio recording  
    //                //goAudioSource.Play(); //Playback the recorded audio  
    //            }

    //            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 50), "Recording in progress...");
    //        }
    //    }
    //    else // No microphone  
    //    {
    //        //Print a red "Microphone not connected!" message at the center of the screen  
    //        GUI.contentColor = Color.red;
    //        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
    //    }

    //}

    public void OnAudioButtonClick()
    {
        if (micConnected)
        {
            //If the audio from any microphone isn't being captured  
            if (!Microphone.IsRecording(null))
            {

                //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource  
                //goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);

                goAudioSource.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
                //goAudioSource.loop = true;
                while (!(Microphone.GetPosition(null) > 0)) { }
                goAudioSource.Play();

                Debug.Log("I'm here");
                audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Audio";
            }

            else //Recording is in progress  
            {
                //Case the 'Stop and Play' button gets pressed  

                Microphone.End(null); //Stop the audio recording
                audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "I'm recording now";
                while (!(Microphone.GetPosition(null) > 0)) { }
                goAudioSource.Play();
                //goAudioSource.Play(); //Playback the recorded audio  
            }
        }
    }

    public void OnStopButtonClick()
    {
        if (Microphone.IsRecording("Built-in Microphone"))
        {
            Microphone.End("Built-in Microphone"); //Stop the audio recording
            //goAudioSource.Play();
        }

        else
        {
            audioButton.GetComponentInChildren<TextMeshProUGUI>().text = "I'm not recording";
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
