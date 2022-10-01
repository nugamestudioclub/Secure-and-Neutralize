using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldInteractions : MonoBehaviour
{
    public float maxInteractDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxInteractDistance))
            {
                if (hit.collider.gameObject.tag == "Battery")
                {
                    hit.collider.gameObject.SetActive(false);
                    AddBattery();
                }
            }
        }
    }

    public void AddBattery()
    {
        Debug.Log("Collected 1 battery.");
    }
}