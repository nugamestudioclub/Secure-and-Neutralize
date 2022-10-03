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
    [SerializeField]
    private Transform exit;
    private bool escaped = false;

    // Start is called before the first frame update
    void Start()
    {
        interactTexts = Regex.Split(dialogueFile.text, Environment.NewLine);
    }
    private void Update()
    {
        if (Vector3.Distance(exit.position, transform.position) < 5&&!escaped)
        {
            PlayerWorldInteractions.goodNumEscaped += 1;
            escaped = true;
        }
    }
}
