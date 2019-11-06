using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpAnimation : MonoBehaviour
{
    // Store speed of scaling
    public float growSmooth = 1.0f;

    // Store target scale for the dominoes
    Vector3 targetScale;

    // Start is called before the first frame update
    void Start()
    {
        // Set target to current size
        targetScale = transform.localScale;

        // Set current size to zero
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Grow dominoes from 0 to target size
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, growSmooth * Time.deltaTime);
    }
}
