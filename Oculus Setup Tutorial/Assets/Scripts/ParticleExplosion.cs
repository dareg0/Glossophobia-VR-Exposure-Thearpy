using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    // Store trophy object
    public GameObject originalObject;

    // Store particle prefab
    public GameObject particlePrefab;

    // Store whether the trophy has exploded
    bool alreadyExploded;

    // Store how many particles to explode into
    public int particleCount;

    // Store min and max particle sizes
    public float particleMinSize;
    public float particleMaxSize;

    // Store position of spark particles
    Vector3 trophySparksPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the trophy has been picked up and has not exploded yet, run the Exploding function
        if (originalObject.gameObject.activeSelf == false && alreadyExploded == false)
        {
            Exploding();
            alreadyExploded = true;
        }
    }

    void Exploding()
    {
        trophySparksPos = transform.position;

        // Generate multiple particles as sparks and of different scales
        for (int i = 0; i < particleCount; i++)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
            transform.localScale = Vector3.one * Random.Range(particleMinSize, particleMaxSize);
        }
    }
}
