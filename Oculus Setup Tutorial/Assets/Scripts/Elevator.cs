using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //Elevator cube 1-4 that you want to control in this script
    public GameObject[] elevators;

    //A cube you want to use its position y as reference to the elevators
    public Transform referenceTransform;

    //The position y of the reference cube
    float targetYPos;

    //A bool to show if the elevator switch has been collided with the ball
    bool alreadyCollided;

    //A float number to tweak the movement speed of the elevators in the editor
    [SerializeField]
    float movementSmooth = 1.0f;

    // Store sound effect for elevator rising
    public AudioSource ElevatorRise;

    void Start()
    {
        //TODO Use the pos.y of this transform and assign it to the targetYPos
        targetYPos = referenceTransform.position.y;

    }

    void Update()
    {
        if(alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call MoveUp() for each elevator in the elevators array.
            foreach (GameObject elevator in elevators)
            {
                MoveUp(elevator);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
            ElevatorRise.Play();
        }
    }
  
    void MoveUp(GameObject thisElevator)
    {
        //TODO calculate a taget position for this very elevator, and move it to the target position
        float step = movementSmooth * Time.deltaTime;

        Vector3 elevatorStart = thisElevator.transform.position;
        Vector3 elevatorTarget = new Vector3(thisElevator.transform.position.x, targetYPos, thisElevator.transform.position.z);
        
        thisElevator.transform.position = Vector3.Lerp(elevatorStart, elevatorTarget, step);
    }

        
}
