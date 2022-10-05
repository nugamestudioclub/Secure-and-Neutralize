using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class VictimBehavior : MonoBehaviour
{
    public TextAsset dialogueFile;
    public string[] interactTexts;
    [HideInInspector]
    public bool onWay = false;
    public bool isGood = true;
    
    private Transform exit;
    private bool escaped = false;

    // Start is called before the first frame update
    void Start()
    {
        interactTexts = Regex.Split(dialogueFile.text, Environment.NewLine);
        exit = GameObject.FindGameObjectWithTag("Exit").transform;
    }
    private void Update()
    {
        if (Vector3.Distance(exit.position, transform.position) < 5&&!escaped)
        {
            if (isGood)
                PlayerWorldInteractions.goodNumEscaped += 1;
            else
                PlayerWorldInteractions.badNumEscaped += 1;
            escaped = true;
            gameObject.SetActive(false);
        }
        
    }
}
