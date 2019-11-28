using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkbehaviour : MonoBehaviour
{
    public Vector3 startVelocity;
    public Rigidbody rb;
    public GameObject Spark;
    public float delay;
    public float shrinkSmooth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Random.rotation * startVelocity;
        Invoke("Die", delay);
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * shrinkSmooth);
    }
    void Die()
    {
        Destroy(Spark);//,1);//delay);
    }
}