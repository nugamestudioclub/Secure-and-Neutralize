using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldInteractions : MonoBehaviour
{
    public float maxInteractDistance = 100f;

    private DialogueManager dm;

    public static bool inDialogue = false;

    PlayerToolManager ptm;

    [SerializeField]
    public static int goodNumKilled = 0;
    [SerializeField]
    public static int goodNumEscaped = 0;
    [SerializeField]
    public static int badNumKilled = 0;
    [SerializeField]
    public static int badNumEscaped = 0;
    [SerializeField]
    public static int badNum = 0;
    [SerializeField]
    public static int goodNum = 0;
    [HideInInspector]
    public static bool isGameOver = false;
    public static int peopleLeft = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        dm = GameObject.Find("DialogueBox").GetComponent<DialogueManager>();
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
                else if (hit.collider.gameObject.tag == "Victim")
                {
                    if (!PlayerWorldInteractions.inDialogue)
                    {
                        VictimBehavior victim = hit.transform.parent.gameObject.GetComponent<VictimBehavior>();
                        if(!victim.onWay)
                        dm.SetDialogue(victim.interactTexts,victim.GetComponent<NavigationManager>());

                    }
                }
            }
        }
    }
}