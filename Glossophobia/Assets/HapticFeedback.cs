using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    private IEnumerator coroutineBuzz;

    // Start is called before the first frame update
    void Start()
    {
        coroutineBuzz = Buzz();
    }

    // If Haptic Feedback is started
    public void OnButtonClick()
    {
        StartCoroutine(coroutineBuzz);
    }

    private IEnumerator Buzz()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(1);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(1);
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(1);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(1);
    }
}
