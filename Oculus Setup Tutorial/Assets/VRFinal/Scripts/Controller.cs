using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject m_PersonPrefab;
    public Slider m_PeopleCountSlider;
    public Text outText;

    private int AudienceState;

    private void Awake()
    {
        AudienceState = 0;  // empty
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
    public void OnIncreaseButtonClicked()
    {
        if (AudienceState < 3)
            this.AudienceState += 1;
        ChangeText();
    }

    public void OnDecreaseButtonClicked()
    {
        if (AudienceState > 1)
            this.AudienceState -= 1;
        ChangeText();
    }

    public void ChangeText()
    {
        switch (AudienceState)
        {
            case 1:
                outText.text = "Low Occupancy";
                break;
            case 2:
                outText.text = "Medium Occupancy";
                break;
            case 3:
                outText.text = "Fully Occupied";
                break;
            default:
                outText.text = "Empty";
                break;
        }
    }
}
