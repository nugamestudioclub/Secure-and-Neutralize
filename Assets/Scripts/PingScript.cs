using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingScript : MonoBehaviour
{
    private float timer;


    private void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
