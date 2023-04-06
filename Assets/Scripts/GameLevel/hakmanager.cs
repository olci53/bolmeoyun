using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class hakmanager : MonoBehaviour
{
    [SerializeField] private GameObject kalpler;

    [SerializeField] private Transform hakpanel;

    private GameObject[] kalplist = new GameObject[3]; 

    public void kalpolustur()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject kalp = Instantiate(kalpler, hakpanel);

            kalplist[i] = kalp;

        }

        StartCoroutine(DoRoutine());
    }

    IEnumerator DoRoutine()
    {
        foreach (var kalp in kalplist)
        {
            kalp.GetComponent<CanvasGroup>().DOFade(1, 0.3f);

            yield return new WaitForSeconds(0.1F);
        }

    }







    public void HaklariKontrolEt(int x)
    {
        switch(x)
        {
            case 3:
                kalplist[0].SetActive(true);
                kalplist[1].SetActive(true);
                kalplist[2].SetActive(true);
                break;

            case 2:
                kalplist[0].SetActive(true);
                kalplist[1].SetActive(true);
                kalplist[2].SetActive(false);
                break;

            case 1:
                kalplist[0].SetActive(true);
                kalplist[1].SetActive(false);
                kalplist[2].SetActive(false);
                break;

            case 0:
                kalplist[0].SetActive(false);
                kalplist[1].SetActive(false);
                kalplist[2].SetActive(false);
                break;
        }

    }



}



