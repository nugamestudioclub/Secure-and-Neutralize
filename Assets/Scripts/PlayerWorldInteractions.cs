using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldInteractions : MonoBehaviour
{
    public float maxInteractDistance = 100f;

    private DialogueManager dm;

    public static bool inDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        dm = GameObject.Find("DialogueBox").GetComponent<DialogueManager>();
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
                else if (hit.collider.gameObject.tag == "Victim")
                {
                    if (!PlayerWorldInteractions.inDialogue)
                    {
                        VictimBehavior victim = hit.transform.parent.gameObject.GetComponent<VictimBehavior>();
                        dm.SetDialogue(victim.interactTexts);
                    }
                }
            }
        }
    }

    public void AddBattery()
    {
        Debug.Log("Collected 1 battery.");
    }
}