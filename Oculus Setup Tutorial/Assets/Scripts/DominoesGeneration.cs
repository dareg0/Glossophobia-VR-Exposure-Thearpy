using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoesGeneration : MonoBehaviour
{
    private IEnumerator coroutine;

    // Store instantiation time for coroutine
    public float instantiationTime;

    // Store the object to instantiate
    public GameObject dominoObject;

    // Store whether the ball and platform have collided
    bool alreadyCollided;

    //public float yOffset = 1.5f;

    // Store the offset values for the positioning of the new dominos
    public Vector3 offset = new Vector3 (0.0f, 1.5f, 1.5f);

    // Start is called before the first frame update
    void Start()
    {
        coroutine = GenerateDomino(5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
        }
    }

    private IEnumerator GenerateDomino(int num)
    {
        // Generate new dominoes at specified position and account for the declared offset
        for (int i = 0; i < num; i++) {
            yield return new WaitForSeconds(instantiationTime);
            Instantiate(dominoObject, new Vector3(6.5f, -6.0f+(i * offset.y), 10-(i * offset.z)), Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (alreadyCollided)
        {
            StartCoroutine(coroutine);
        }
    }
}
