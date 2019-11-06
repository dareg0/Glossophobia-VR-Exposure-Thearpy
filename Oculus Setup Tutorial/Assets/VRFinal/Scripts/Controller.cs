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

    public void AudienceCount()
    {
        this.peopleCount = (int)m_PeopleCountSlider.value;
    }

    public void OnSliderChanged(float value)
    {
        if (outText != null)
        {
            outText.text = "<b>Last Interaction:</b>\nUI Slider value: " + value;
        }
    }
}
