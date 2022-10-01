using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightComponent : MonoBehaviour
{
    [SerializeField]
    private Light lighting;
    [SerializeField]
    private bool testing;

    public void TurnOn()
    {
        lighting.enabled = true;
    }
    public void TurnOff()
    {
        lighting.enabled = false;
    }

    public void Toggle()
    {
        lighting.enabled = !lighting.enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testing)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Toggle();
            }
        }
    }
}
