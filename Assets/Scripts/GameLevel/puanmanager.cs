using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class puanmanager : MonoBehaviour
{
    [SerializeField] private Text puantext;
    [SerializeField] private GameObject puan;
    private int toplamPuan;
    private int puanArtis;



    private void Start()
    {
        puan.GetComponent<CanvasGroup>().DOFade(1, 0.7f);
        
        puantext.text = toplamPuan.ToString();
    }


    public void puanArttir(string ZorlukSeviyesi)
    {
        switch (ZorlukSeviyesi)
        {
            case "kolay":
                puanArtis = 5;
                break;

            case "orta":
                puanArtis = 10;
                break;

            case "zor":
                puanArtis = 15;
                break;



        }

        toplamPuan += puanArtis;

        puantext.text = toplamPuan.ToString();
    }



}
