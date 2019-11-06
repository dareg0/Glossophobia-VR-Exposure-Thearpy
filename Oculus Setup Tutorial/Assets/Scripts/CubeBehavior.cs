using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeBehavior : MonoBehaviour
{
    Camera myCam;

    public string standByText;
    public string startedText;

    Rigidbody rb;

    // Store transformation sphere object
    public Transform sphere;

    // Store new sphere player
    public GameObject playerSphere;

    // Store whether player cube and transformation sphere have collided
    bool alreadyCollided;

    // Store instructions for how to start the game
    public TextMeshProUGUI instructions;
    TextMeshProUGUI updatedInstructions;

    // Store transformation sound effect
    public AudioSource Transformation;

    //Store audio source for mouse click
    public AudioSource Mouse;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        updatedInstructions = instructions.GetComponent<TMPro.TextMeshProUGUI>();
        updatedInstructions.text = standByText;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            // Call Interact function if the mouse is clicked
            if (Physics.Raycast(ray, out hit, 100))
            {
                Mouse.Play();
                Interact(hit);
            }
        }

        // If the player cube collides with the transformation sphere, make the cube inactive and call the Drop function
        if (alreadyCollided == true)
        {
            Transformation.Play();
            gameObject.SetActive(false);
            Invoke("Drop", 0.2f);
        }
    }

    void Interact(RaycastHit hit)
    {
        // If user clicks on the player cube, turn on gravity
        if (hit.collider.name == "PlayerCube")
        {
            rb.useGravity = true;
            updatedInstructions.text = startedText;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has a tag of "TransformSphere", if so then set the boolean alreadyCollided to true
        if (collision.gameObject.CompareTag("TransformSphere"))
        {
            alreadyCollided = true;
        }
    }

    // Make the player sphere active and let it drop
    private void Drop()
    {
        playerSphere.gameObject.SetActive(true);
    }
}
