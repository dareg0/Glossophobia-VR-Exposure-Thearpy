using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Store trophy rotation speed
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Rotate the trophy at given angles and speed
        transform.Rotate(new Vector3(45, 45, 45) * speed * Time.deltaTime);
    }
}
