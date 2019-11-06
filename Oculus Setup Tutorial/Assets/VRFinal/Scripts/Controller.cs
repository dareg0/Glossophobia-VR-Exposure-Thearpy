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

    private void Awake()
    {
        AudienceNum = 0;  // empty
        currentState = LowOccup;
        currentState.SetActive(false);
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
        if (outText != null)
        {
            outText.text = "";
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
}
