using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformC : MonoBehaviour
{
    // Store speed of platform movement
    public float speed;
    Camera myCam;

    // Store angles to rotate towards
    float xRotation = 40.0f;

    // Store whether platform has been clicked on
    bool clicked;

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
                if (hit.collider.name == "PointCPlatform" || hit.collider.name == "PointCWall1" || hit.collider.name == "PointCWall2" || hit.collider.name == "PointCWall3")
                {
                    clicked = true;
                }
            }
        }

        // If clicked on Platform C, rotate towards the designated angles.
        if (clicked)
        {
            // Rotate
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xRotation, -180.0f, 0), speed * Time.deltaTime);
        }
    }
}
