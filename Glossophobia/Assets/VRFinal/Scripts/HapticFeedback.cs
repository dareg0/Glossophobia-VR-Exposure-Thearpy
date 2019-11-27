using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HapticFeedback : MonoBehaviour
{
    private IEnumerator coroutineBuzz;
    public GameObject breathingSphere;

    // Store speed of scaling
    public float growSmooth = 1.2f;

    // Store target scale
    Vector3 targetScale;

    bool start;
    bool grow;

    public GameObject beginButton;
    public GameObject endButton;
    public Text breathe;
    public GameObject startText;
    public Text EMDRText;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        // Set target to current size
        //targetScale = transform.localScale;
        targetScale = new Vector3(4.5f, 4.5f, 0.01f);

        // Set current size to zero
        breathingSphere.transform.localScale = Vector3.zero;

        coroutineBuzz = Buzz();

        count = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true) {
            if (count > 0)
            {
                if (grow)
                {
                    breathe.text = "Breathe In";

                    //StartCoroutine(coroutineBuzz);
                    if (breathingSphere.transform.localScale.x < 4.4f)
                    {
                        breathingSphere.transform.localScale = Vector3.Lerp(breathingSphere.transform.localScale, targetScale, growSmooth * Time.deltaTime);
                    }

                    else
                    {
                        grow = false;
                    }
                }
                else
                {
                    breathe.text = "Breathe Out";

                    if (breathingSphere.transform.localScale.x > 0.1f)
                    {
                        breathingSphere.transform.localScale = Vector3.Lerp(breathingSphere.transform.localScale, Vector3.zero, growSmooth * Time.deltaTime);
                    }
                    else
                    {
                        count--;
                        Debug.Log("--------------------" + count);
                        grow = true;
                    }
                }
            }

            if (count == 0)
            {
                breathe.text = "";
                //start = false;
            }
        }

        else if (!start)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            breathe.text = "";
            breathingSphere.transform.localScale = Vector3.zero;
        }
        
    }

    // If Haptic Feedback is started
    public void OnBeginButtonClick()
    {
        startText.SetActive(false);
        beginButton.SetActive(false);
        endButton.SetActive(true);
        StartCoroutine(coroutineBuzz);
        start = true;
    }

    public void OnEndButtonClick()
    {
        endButton.SetActive(false);
        beginButton.SetActive(true);
        EMDRText.text = "";
        startText.SetActive(true);
        start = false;

    }

    IEnumerator Buzz()
    {
        yield return new WaitForSeconds(32);
        EMDRText.text = "Think about the last time you spoke in front of a group.";
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);

            EMDRText.text = "Focus on someone who made you feel comfortable in that situation.";
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);

            EMDRText.text = "Keep that person in mind as you begin practicing your speech.";
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(1);

            EMDRText.text = "You're ready to start.";
        

    }
}
