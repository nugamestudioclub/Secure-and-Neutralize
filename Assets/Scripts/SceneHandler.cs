using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void StartGame()
    {
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1.2f);
        
        LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }
}
