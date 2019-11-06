using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Hello my name is Meera";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "Today I'm going to talk to you about my VR project";

    }
}
