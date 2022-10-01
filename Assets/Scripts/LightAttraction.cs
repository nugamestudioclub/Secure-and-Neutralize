using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttraction : MonoBehaviour
{

    public Rigidbody rb;
    const float MAX_FORCE = 4;
    float force;


    [SerializeField] GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Attract()
    {

        Vector3 direction = Vector3.Normalize(transform.position - monster.transform.position);
        float distance = Vector3.Distance(transform.position, monster.transform.position);

        float distSquared = Mathf.Pow(distance, 2);

        if (distSquared > 10)
            force = 0;
        else
            force = MAX_FORCE / distSquared;// Mathf.Clamp(MAX_FORCE - distance, 0, MAX_FORCE);
        
        rb.AddForce(-direction * force);
        
        Debug.Log("Force: " + force);

    }

    // Update is called once per frame
    void Update()
    {
        Attract();
    }

    
}
