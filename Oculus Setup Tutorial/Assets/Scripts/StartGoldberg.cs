using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGoldberg : MonoBehaviour
{
    Camera myCam;

    // Store starting text
    public string standByText;
    public string startedText;

    // Store TM Pro UI objects to modify the text later
    public TextMeshProUGUI instructions;
    TextMeshProUGUI updatedInstructions;

    // Store sound effect for disappearing platform
    public AudioSource PlatformDisappear;

    //Store audio source for mouse click
    public AudioSource Mouse;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        updatedInstructions = instructions.GetComponent<TMPro.TextMeshProUGUI>();

        // Update TM Pro text with given stand by text
        updatedInstructions.text = standByText;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Check if mouse has been clicked
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100)){
                Mouse.Play();
                Interact(hit);
            }
        }
    }

    void Interact(RaycastHit hit)
    {
        // If clicked on Start Platform, set the platform to false and update the instructions text
        if (hit.collider.name == "StartPlatform")
        {
            PlatformDisappear.Play();
            hit.collider.gameObject.SetActive(false);
            updatedInstructions.text = startedText;
        }
    }
}
