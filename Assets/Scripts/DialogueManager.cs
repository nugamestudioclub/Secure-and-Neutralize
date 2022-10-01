using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private GameObject backPanel;
    private GameObject dialogueTextObject;
    private TMP_Text dialogueText;
    private GameObject saveButton;
    private GameObject doomButton;

    private string[] currentDialogue;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        backPanel = transform.Find("Panel").gameObject;
        backPanel.SetActive(false);
        dialogueTextObject = transform.Find("DialogueText").gameObject;
        dialogueText = dialogueTextObject.GetComponent<TMP_Text>();
        dialogueTextObject.SetActive(false);
        saveButton = transform.Find("SaveButton").gameObject;
        saveButton.SetActive(false);
        doomButton = transform.Find("DoomButton").gameObject;
        doomButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerWorldInteractions.inDialogue)
        {
            AdvanceDialogue();
        }
    }

    public void SetDialogue(string[] dialogueArray)
    {
        currentIndex = 0;
        currentDialogue = dialogueArray;
        backPanel.SetActive(true);
        saveButton.SetActive(false);
        doomButton.SetActive(false);
        dialogueTextObject.SetActive(true);
        dialogueText.text = currentDialogue[0];
        PlayerWorldInteractions.inDialogue = true;
    }

    public void AdvanceDialogue()
    {
        currentIndex++;
        if (currentIndex >= currentDialogue.Length)
        {
            dialogueText.text = "";
            dialogueTextObject.SetActive(false);
            saveButton.SetActive(true);
            doomButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            dialogueText.text = currentDialogue[currentIndex];
        }
    }

    public void EndDialogue()
    {
        backPanel.SetActive(false);
        saveButton.SetActive(false);
        doomButton.SetActive(false);
        PlayerWorldInteractions.inDialogue = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SaveChosen()
    {
        EndDialogue();
    }

    public void DoomChosen()
    {
        EndDialogue();
    }
}