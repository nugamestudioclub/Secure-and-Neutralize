using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Animator ui_animator;

    [SerializeField]
    GameObject t;

    [SerializeField]
    AudioSource bgm;

    public delegate void GameStart();
    public static GameStart GSEffects;

    private void Start()
    {
        ui_animator = GetComponent<Animator>();

        AudioManagerScript.instance.PlaySound(bgm, "Radar theme v2");
    }

    public void PlayGameAnim()
    {
        t.SetActive(false);
        ui_animator.Play("GameStart");

        GSEffects.Invoke();
    }

    public void LoadOptions()
    {
        t.SetActive(false);
        ui_animator.Play("OpenOptions");
    }

    public void DisableOptions()
    {
        ui_animator.Play("OpenMenu");
    }

    public void ToggleText()
    {
        t.SetActive(!t.activeInHierarchy);
    }
}
