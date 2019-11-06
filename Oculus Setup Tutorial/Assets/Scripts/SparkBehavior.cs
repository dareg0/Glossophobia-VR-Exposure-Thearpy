using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBehavior : MonoBehaviour
{
    // Store velocity for trophy sparks
    public Vector3 startVelocity;

    Rigidbody rb;

    // Store delay time for sparks to die
    public float delay;

    // Store speed at which sparks will shrink
    public float shrinkSmooth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Randomize each sparks velocity
        rb.velocity = Random.rotation * startVelocity;

        // Destroy spark after designated delay time
        Invoke("Die", delay);
    }

    // Update is called once per frame
    void Update()
    {
        // Shrink sparks from current size to 0
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSmooth);
    }

    void Die()
    {
        // Destroy sparks
        Destroy(gameObject);
    }
}
