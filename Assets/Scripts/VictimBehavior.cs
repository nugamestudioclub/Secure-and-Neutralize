using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class VictimBehavior : MonoBehaviour
{
    public TextAsset dialogueFile;
    public string[] interactTexts;

    // Start is called before the first frame update
    void Start()
    {
        interactTexts = Regex.Split(dialogueFile.text, Environment.NewLine);
    }
}
