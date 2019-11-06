using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlope : MonoBehaviour
{
    public GameObject slope;

    // Assign an absolute rotation using eulerAngles
    float yRotation = 310.0f;

    //A bool to show if the slope switch has been collided with the ball
    bool alreadyCollided;

    float speed = 1.0f;

    // Store sound effect for when slope rotates
    public AudioSource SlopeRotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call Rotate()
    
            Rotate(slope);
 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
            SlopeRotate.Play();
        }
    }

    void Rotate(GameObject thisSlope)
    {
        yRotation += Input.GetAxis("Horizontal");

        thisSlope.transform.rotation = Quaternion.Slerp(thisSlope.transform.rotation, Quaternion.Euler(0, 0, yRotation), Time.deltaTime * speed);
    }
}
