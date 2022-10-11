using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFlashlightComponent : MonoBehaviour
{
    public int remaining = 20;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drop", 0.0001f, 20);
    }
    public void Toggle()
    {
        if (!light.enabled&&remaining>0)
        {
            remaining = (int)Mathf.Clamp(remaining-1,0,Mathf.Infinity);
        }
        light.enabled = !light.enabled;
    }
    public void Drop()
    {
        remaining = (int)Mathf.Clamp(remaining - 1, 0, Mathf.Infinity);
        if (remaining <= 0)
        {
            light.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
