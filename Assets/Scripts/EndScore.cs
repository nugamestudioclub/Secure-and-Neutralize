using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private Button reset;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        reset.onClick.AddListener(LoadBackToHome);
        print("Good Guys Killed:"+PlayerWorldInteractions.goodNumKilled.ToString()+"/"+PlayerWorldInteractions.goodNum.ToString());
        print("Bad Guys Killed:" + PlayerWorldInteractions.badNumKilled.ToString()+"/"+PlayerWorldInteractions.badNum.ToString());
        if (PlayerWorldInteractions.peopleLeft > 0)
        {
            title.text = "GAME OVER";
        }
        else
        {
            title.text = "<color=green>ESCAPED!</color>";
        }
        int finalScore = 0;
        finalScore += PlayerWorldInteractions.goodNumEscaped+PlayerWorldInteractions.badNumKilled;
        finalScore -= (PlayerWorldInteractions.badNumEscaped + PlayerWorldInteractions.goodNumKilled);
        int maxScore = PlayerWorldInteractions.goodNumEscaped + PlayerWorldInteractions.goodNumKilled + PlayerWorldInteractions.badNumEscaped + PlayerWorldInteractions.badNumKilled;
        score.text = score.text.Replace("{0}", PlayerWorldInteractions.goodNumEscaped.ToString())
            .Replace("{1}", PlayerWorldInteractions.badNumEscaped.ToString())
            .Replace("{2}", PlayerWorldInteractions.goodNumKilled.ToString())
            .Replace("{3}", PlayerWorldInteractions.badNumKilled.ToString())
            .Replace("{4}", finalScore.ToString() + "/" + maxScore.ToString());

    }
    public void LoadBackToHome()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
