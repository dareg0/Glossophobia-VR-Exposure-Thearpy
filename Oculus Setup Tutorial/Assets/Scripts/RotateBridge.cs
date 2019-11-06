using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBridge : MonoBehaviour
{
    // Store speed of platform movement
    public float speed;

	Camera myCam;

    // Store angles to rotate towards
	float yRotation = 90.0f;
	float zRotation = -20.0f;

    // Store whether the bridge has been clicked on
	bool clicked;

    // Store how many times the bridge has been clicked on
    int clickCount;

    // Store sound effect for when bridge rotates
    public AudioSource RotateUp;
    public AudioSource RotateDown;

    void Start()
	{
		myCam = Camera.main;
        clickCount = 0;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

            // Check if the mouse click was on the Bridge object
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.name == "Bridge" || hit.collider.name == "BridgeWall1" || hit.collider.name == "BridgeWall2")
				{
                    RotateDown.Play();
                    clicked = true;
                    clickCount += 1;
                }
			}
		}

        // If the Bridge is clicked on, move it either towards the new angles or back to the original place, depending on how
        // many times it is clicked.
        if (clicked)
        {
            if (clickCount % 2 == 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yRotation, zRotation), Time.deltaTime * speed);

            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);

            }
        }
    }
}

