using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text batteriesTxt;
    [SerializeField]
    private TMP_Text peopleLeft;
    [SerializeField]
    private PlayerToolManager toolManager;

    private int maxNumppl = 0;
    private int totalVictims = 0;
    VictimBehavior[] victims;

    // Start is called before the first frame update
    void Start()
    {
        victims = GameObject.FindObjectsOfType<VictimBehavior>();
        foreach(VictimBehavior victim in victims)
        {
            if (victim.isGood)
            {
                maxNumppl++;
                PlayerWorldInteractions.goodNum += 1;

            }
            else
            {
                PlayerWorldInteractions.badNum += 1;
            }
        }
        print("Updated Player World nums good:"+PlayerWorldInteractions.goodNum);
        totalVictims = victims.Length;
    }

    // Update is called once per frame
    void Update()
    {
        peopleLeft.text = PlayerWorldInteractions.peopleLeft.ToString();



        batteriesTxt.text = toolManager.flashlight.remaining.ToString();
        

        int alive = 0;
        foreach (VictimBehavior victim in victims)
        {
            if (victim.gameObject.activeInHierarchy)
            {
                alive += 1;
            }
        }
        PlayerWorldInteractions.peopleLeft = alive;
        if (alive == 0)
        {
            SceneManager.LoadScene("EndGameScore");
        }
    }
}
