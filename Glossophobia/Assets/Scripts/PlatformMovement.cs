using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Assign an absolute rotation using eulerAngles
    float xRotation = -30.0f;

    //A bool to show if the slope switch has been collided with the ball
    bool alreadyCollided;

    float speed = 2.0f;

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
            Rotate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
        }
    }

    void Rotate()
    {
        xRotation += Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xRotation, 0, 0), Time.deltaTime * speed);

    }
}
