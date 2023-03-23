using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaslangicManager : MonoBehaviour
{
    [SerializeField] private Text Baslangictext;

    [SerializeField] private GameObject BaslangicPanel;


    void sahnegecis()
    {
        SceneManager.LoadScene("menuLevel");
    }

    void baslangicpanel()
    {
        BaslangicPanel.GetComponent<CanvasGroup>().DOFade(0, 1f);
        
        Baslangictext.GetComponent<CanvasGroup>().DOFade(1, 2f);

        Baslangictext.text = "FENERBAHÇE";
        Invoke("sahnegecis", 3f);
    }

    private void Start()
    {
        baslangicpanel();
    }
}
