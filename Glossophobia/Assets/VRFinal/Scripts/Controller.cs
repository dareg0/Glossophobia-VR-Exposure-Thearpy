using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Four States Prefab
    public GameObject FullyOccup;
    public GameObject MedOccup;
    public GameObject LowOccup;
    public GameObject EmptyOccup;
    public GameObject uicanvas;
    public Slider noiseslider;
    public Text outText;

    private int AudienceNum;

    private GameObject currentState;

    private bool scriptEnabled;
    public GameObject scriptButton;

    public GameObject emoji1;
    public GameObject emoji2;
    private bool emojiEnabled;
    private bool timerEnabled;

    private void Awake()
    {
        AudienceNum = 0;  // empty
        scriptEnabled = false;
        currentState = LowOccup;
        currentState.SetActive(false);

        emoji1.SetActive(false);
        emoji2.SetActive(false);
        emojiEnabled = false;
        timerEnabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnSliderChanged()
    //{
    //    this.peopleCount = (int)m_PeopleCountSlider.value;
    //    if (outText != null)
    //    {
    //        outText.text = "UI Slider clicked. Current Audience Count: " + peopleCount;
    //    }
    //}

    public void ScriptButton()
    {
        scriptEnabled = !scriptEnabled;

        if (scriptEnabled)
        {
            scriptButton.GetComponentInChildren<Text>().text = "Pause Script";
            StartCoroutine("TheSequence");
        }
        else
        {
            scriptButton.GetComponentInChildren<Text>().text = "Resume Script";
        }
    }

    public void OnIncreaseButtonClicked()
    {
        if (AudienceNum < 3)
            this.AudienceNum += 1;
        ChangeText();
    }

    public void OnDecreaseButtonClicked()
    {
        if (AudienceNum > 0)
            this.AudienceNum -= 1;
        ChangeText();
    }

    public void onAudienceEmojiClicked()
    {
        emojiEnabled = true;
    }

    public void onTimerEnabled()
    {
        timerEnabled = true;
    }

    public void onStartClicked()
    {
        uicanvas.SetActive(false);
    }
    public void onSliderChange()
    {

    }


    public void ChangeText()
    {
        // disable the current state
        currentState.SetActive(false);
        switch (AudienceNum)
        {
            case 1:
                outText.text = "Low Occupancy";
                currentState = LowOccup;
                break;
            case 2:
                outText.text = "Medium Occupancy";
                currentState = MedOccup;
                break;
            case 3:
                outText.text = "Fully Occupied";
                currentState = FullyOccup;
                break;
            case 0:
                outText.text = "Empty";
                currentState = EmptyOccup;
                break;
        }
        currentState.SetActive(true);
    }

    IEnumerator TheSequence()
    {
        //activate timer
        if(emojiEnabled == true)
        {
            yield return new WaitForSeconds(1);
            outText.text = "Hello my name is Meera";
            yield return new WaitForSeconds(4);
            outText.text = "Today I'm going to talk to you about my VR project";
            emoji1.SetActive(true);
            yield return new WaitForSeconds(1);
            emoji1.SetActive(false);
            yield return new WaitForSeconds(2);
            outText.text = "My project is about glossophobia, ";
            emoji2.SetActive(true);
            yield return new WaitForSeconds(1);
            emoji2.SetActive(false);
            yield return new WaitForSeconds(2);
            outText.text = "which is the fear of public speaking.";

        }
        else
        {
            yield return new WaitForSeconds(1);
            outText.text = "Hello my name is Meera";
            yield return new WaitForSeconds(4);
            outText.text = "Today I'm going to talk to you about my VR project";
            emoji1.SetActive(false);
            yield return new WaitForSeconds(1);
            emoji1.SetActive(false);
            yield return new WaitForSeconds(2);
            outText.text = "My project is about glossophobia, ";
            emoji2.SetActive(false);
            yield return new WaitForSeconds(1);
            emoji2.SetActive(false);
            yield return new WaitForSeconds(2);
            outText.text = "which is the fear of public speaking.";

        }

    }
}
