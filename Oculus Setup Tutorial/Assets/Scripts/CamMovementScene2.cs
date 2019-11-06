using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementScene2 : MonoBehaviour
{
    //The target object that this camera is focosing on (changes from cube to sphere)
    public GameObject targetObject1;
    public GameObject targetObject2;

    //A float used to tweak the camera movement
    [SerializeField]
    float cameraMovementSmooth = 1.0f;

    //An offset between camera and the target obejct
    Vector3 offset1;
    Vector3 offset2;

    void Start()
    {
        //TODO Calculate the offset between the camera and the target game object
        offset1 = transform.position - targetObject1.transform.position;
        offset2 = transform.position - targetObject2.transform.position;
    }

    void Update()
    {
        // Depending on which player is active, move the camera position appropriately
        if (targetObject1.gameObject.activeSelf == true) {
            transform.position = Vector3.Lerp(transform.position, targetObject1.transform.position + offset1, cameraMovementSmooth * Time.deltaTime);
        }
        else if (targetObject2.gameObject.activeSelf == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetObject2.transform.position + offset2, cameraMovementSmooth * Time.deltaTime);

        }
    }
}
