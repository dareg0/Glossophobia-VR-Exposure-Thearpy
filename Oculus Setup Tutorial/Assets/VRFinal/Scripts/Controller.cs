using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject m_PersonPrefab;
    public Slider m_PeopleCountSlider;
    public Text outText;

    private int peopleCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSliderChanged()
    {
        this.peopleCount = (int)m_PeopleCountSlider.value;
        if (outText != null)
        {
            outText.text = "UI Slider clicked. Current Audience Count: " + peopleCount;
        }
    }
    public void OnIncreaseButtonClicked()
    {
        this.peopleCount += 1;
        if (outText != null)
        {
            outText.text = "UI Button clicked. Current Audience Count + 1: " + peopleCount;
        }
    }

    public void OnDecreaseButtonClicked()
    {
        this.peopleCount -= 1;
        if (outText != null)
        {
            outText.text = "UI Button clicked. Current Audience Count - 1: " + peopleCount;
        }
    }
}
