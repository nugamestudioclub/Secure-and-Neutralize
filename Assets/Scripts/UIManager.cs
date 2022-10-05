using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    Animator ui_animator;


    private void Start()
    {
        ui_animator = GetComponent<Animator>();
        
    }

    public void PlayGameAnim()
    {
        ui_animator.Play("GameStart");
    }

    public void LoadOptions()
    {
        ui_animator.Play("OpenOptions");
    }

    public void DisableOptions()
    {
        ui_animator.Play("OpenMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
