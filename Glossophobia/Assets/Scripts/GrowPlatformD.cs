using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlatformD : MonoBehaviour
{
    // Speed of growing/moving the platform
    public float growSmooth = 1.0f;

    // Store the largest and smallest size for platform to scale to
    Vector3 largeTargetScale;
    Vector3 smallTargetScale;

    // Store the start and end positions for the platform to move from/to
    Vector3 platformStart;
    Vector3 platformTarget;

    // Store a reference to move the platform towards
    public Transform referenceTransform;

    // Store the y coordinate of the reference
    float targetYPos;

    // Store whether the object has been clicked
    bool clicked;
    
    // Store how often an object has been clicked on
    int clickCount;

    // Store sound effect for when platform grows
    public AudioSource Grow;

    // Start is called before the first frame update
    void Start()
    {
        // Initiate variables
        largeTargetScale = new Vector3(4.0f, transform.localScale.y, 4.0f);
        smallTargetScale = new Vector3(2.0f, 0.2f, 2.0f);

        clickCount = 0;

        targetYPos = referenceTransform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the start and end positions
        platformStart = transform.position;
        platformTarget = new Vector3(transform.position.x, targetYPos, transform.position.z);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If the mouse clicks on Platform D, then set clicked to 'true'
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "PointDWall1" || hit.collider.name == "PointDWall2" || hit.collider.name == "PointDWall3" || hit.collider.name == "PointDWall4" || hit.collider.name == "PointDPlatform")
                {
                    Grow.Play();
                    clicked = true;
                    clickCount += 1;
                }
            }
        }

        // When clicked, grow the platform, wait 4 seconds and then move platform up
        if (clicked == true && clickCount == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, largeTargetScale, growSmooth * Time.deltaTime);
            Invoke("MoveUp", 4);
        }
    }

    // Move platform up and simultaneously shrink the scale so it's easy to see the ball
    void MoveUp()
    {
        transform.position = Vector3.Lerp(platformStart, platformTarget, growSmooth * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, smallTargetScale, growSmooth * Time.deltaTime);
    }
   
}
