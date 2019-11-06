using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformB : MonoBehaviour
{
    // Store speed of platform movement
    public float speed;

    Camera myCam;

    // Store a reference to move the platform towards
    public Transform referenceTransform;

    // Store the z coordinate of the reference
    float targetZPos;

    // Store the start and end positions for the platform to move from/to
    Vector3 platformStart;
    Vector3 platformTarget;
    Vector3 originalPlatform;

    // Store whether object has been clicked
    bool clicked;

    // Store how many times the object has been clicked
    int clickCount;

    // Store sound effect for whenever ball lands
    public AudioSource Slide;

    void Start()
    {
        // Initialize variables
        myCam = Camera.main;
        targetZPos = referenceTransform.position.z;
        clickCount = 0;
        originalPlatform = transform.position;
    }

    void Update()
    {
        // Set the start and end positions
        platformStart = transform.position;
        platformTarget = new Vector3(transform.position.x, transform.position.y, targetZPos - 6.0f);

        // Check if object clicked is Platform B
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "PointBPlatform" || hit.collider.name == "PointBWall1" || hit.collider.name == "PointBWall2" || hit.collider.name == "PointBWall3")
                {
                    Slide.Play();
                    clicked = true;
                    clickCount += 1;
                }
            }
        }

        // If platform B is clicked, move it either towards the reference or away from the reference, depending on which
        // click it is. E.g. first click move towards, second click move away.
        if (clicked)
        {
            if (clickCount % 2 == 1)
            {
                transform.position = Vector3.Lerp(platformStart, platformTarget, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(platformStart, originalPlatform, speed * Time.deltaTime);
            }

        }
    }

}
