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

    [SerializeField] private Text sorutext;

    List<int> bolumDegerleriList = new List<int>();

    int bolunensayi, bolensayi;

    int dogrusonuc;

    int kacincisoru;

    int butondegeri;

    bool butonaBasilsinmi;

    public void kareolustur()
    {
        for (int i = 0;i<25;i++)
        {
            GameObject kare = Instantiate(kareler,karelerPaneli);
            kare.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());

            karelerDizisi[i] = kare;

        }

        bolumdegerlerinitextyazdir();
        StartCoroutine(DoFadeRoutine());
        Invoke("sorupaneliniac", 2f);
        SoruSor();
    }

    void ButonaBasildi()
    {
       if (butonaBasilsinmi)
        {
            butondegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            sonucdogrumu();
        }
        

    }


    private void Start()
    {
        sorupaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        Invoke("kareolustur", 0.7f);
        


        
    }


    void sonucdogrumu()
    {
        if (butondegeri == dogrusonuc)
        {
            Debug.Log("dogru");
        }
        else
        {
            Debug.Log("yanlýþ");
        }
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
            int Rastgeledeger = Random.Range(1, 13);
            bolumDegerleriList.Add(Rastgeledeger);

            kare.transform.GetChild(0).GetComponent<Text>().text = Rastgeledeger.ToString();

        }
    }

    void sorupaneliniac()
    {
        sorupaneli.GetComponent<RectTransform>().DOScale(1.0f, 0.3f);
        butonaBasilsinmi = true;
    }

   void SoruSor()
    {

        bolensayi = Random.Range(2, 11);
        
        kacincisoru = Random.Range(0, bolumDegerleriList.Count);

        dogrusonuc = bolumDegerleriList[kacincisoru];
        
        bolunensayi = bolensayi * dogrusonuc;
        sorutext.text = bolunensayi.ToString() + ":" + bolensayi;
    }


}
