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

    public Slider m_PeopleCountSlider;
    public Text outText;

    private int AudienceNum;

    private GameObject currentState;

    private bool scriptEnabled;
    public GameObject scriptButton;

    public TextAsset m_subscript_text;

    private List<string> textList;
    public GameObject emoji1;
    public GameObject emoji2;
    private bool emojiEnabled;

    private int textIndex;

    private void Awake()
    {
        AudienceNum = 0;  // empty
        textIndex = 0;
        scriptEnabled = false;
        currentState = LowOccup;
        currentState.SetActive(false);
        textList = new List<string>();
        emojiEnabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        readText(m_subscript_text);
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
            //StartCoroutine("TheSequence");
            StartCoroutine("Emoji");
        }
        else
        {
            scriptButton.GetComponentInChildren<Text>().text = "Resume Script";
        }
    }

    IEnumerator Emoji()
    {
        yield return new WaitForSeconds(5);
        emoji1.SetActive(true);
        yield return new WaitForSeconds(1);
        emoji1.SetActive(false);
        yield return new WaitForSeconds(5);
        emoji2.SetActive(true);
        yield return new WaitForSeconds(1);
        emoji2.SetActive(false);
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


    void readText(TextAsset txt)
    {
        if (txt != null)
        {
            var arrayString = txt.text.Split('\n');
            foreach (var line in arrayString)
                textList.Add(line);
        }
    }

    private void FixedUpdate()
    {
        scrollScript();
    }

    void scrollScript()
    {
        if (!scriptEnabled || textList == null)
            return;

        if (OVRInput.GetDown(OVRInput.Button.One))  // A's pressed
        {
            textIndex += 1;
            if (textList[textIndex] != null)
                outText.text = textList[textIndex];
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))  // B's pressed
        {
            textIndex -= 1;
            if (textList[textIndex] != null)
                outText.text = textList[textIndex];
            else
                outText.text = "[The End]";
        }
    }
}
