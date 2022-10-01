using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldInteractions : MonoBehaviour
{
    public float maxInteractDistance = 100f;

    PlayerToolManager ptm;

    // Start is called before the first frame update
    void Start()
    {
        ptm = GetComponent<PlayerToolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxInteractDistance))
            {
                if (ptm.ProcessPickup(hit.collider.gameObject.tag))
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}