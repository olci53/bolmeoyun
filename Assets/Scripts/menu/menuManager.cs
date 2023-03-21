using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField] private GameObject startbtn, exitbtn;

    void Fadeout()
    {
        startbtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        exitbtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f).SetDelay(0.5f);
    }

    private void Start()
    {
        Fadeout();
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    public void StartGameLevel()
    {
        SceneManager.LoadScene("gameLevel");
    }
         
}
