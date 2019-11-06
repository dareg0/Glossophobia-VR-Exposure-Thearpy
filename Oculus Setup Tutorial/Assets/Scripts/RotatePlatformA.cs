using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformA : MonoBehaviour
{
    // Store speed of platform movement
    public float speed;
    Camera myCam;

    // Store angles to rotate towards
    float xRotation = 30.0f;

    // Store whether platform has been clicked on
    bool clicked;

    // Store sound effect for when platform rotates
    public AudioSource Rotate;

    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "PointAPlatform" || hit.collider.name == "PointAWall1" || hit.collider.name == "PointAWall2" || hit.collider.name == "PointAWall3")
                {
                    Rotate.Play();
                    clicked = true;
                }
            }
        }

        // If clicked on Platform A, rotate towards the designated angles.
        if (clicked)
        {
            // Rotate
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xRotation, 90.0f, 0), speed * Time.deltaTime);
        }
    }
}
