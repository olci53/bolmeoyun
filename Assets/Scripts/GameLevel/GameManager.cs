using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject kareler;

    [SerializeField] private Transform karelerPaneli;

    private GameObject[] karelerDizisi = new GameObject[25];

    [SerializeField] private Transform sorupaneli;

    public void kareolustur()
    {
        for (int i = 0;i<25;i++)
        {
            GameObject kare = Instantiate(kareler,karelerPaneli);
            karelerDizisi[i] = kare;

        }

        bolumdegerlerinitextyazdir();
        StartCoroutine(DoFadeRoutine());
        Invoke("sorupaneliniac", 2f);
        
    }

    private void Start()
    {
        sorupaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        Invoke("kareolustur", 0.7f);
        


        
    }

    IEnumerator DoFadeRoutine() 
    {
        foreach(var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.3f);

            yield return new WaitForSeconds(0.1f);
        }
        
    
    }

    void bolumdegerlerinitextyazdir()
    { 
        foreach(var kare in karelerDizisi)
        {
            int Rastgeledeger = Random.Range(0, 13);

            kare.transform.GetChild(0).GetComponent<Text>().text = Rastgeledeger.ToString();

        }
    }

    void sorupaneliniac()
    {
        sorupaneli.GetComponent<RectTransform>().DOScale(1.0f, 0.3f);

    }

}
