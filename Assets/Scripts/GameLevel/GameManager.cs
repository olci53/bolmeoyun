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

    [SerializeField] private Sprite[] kareSprites;

    [SerializeField] private GameObject sonucPanel;

    GameObject gecerlikare;

    List<int> bolumDegerleriList = new List<int>();

    int bolunensayi, bolensayi;

    int dogrusonuc;

    int kacincisoru;

    int butondegeri;

    bool butonaBasilsinmi;

    int kalanHak;

    string SorununZorlukSeviyesi;

    hakmanager hakmanager;

    puanmanager Puanmanager;



    private void Awake()
    {
        sonucPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

    }

    public void hakolustur()
    {
        kalanHak = 3;

        hakmanager = Object.FindObjectOfType<hakmanager>();

        Puanmanager = Object.FindObjectOfType<puanmanager>();

        hakmanager.HaklariKontrolEt(kalanHak);
    }



    public void kalpolusturma()
    {
        hakmanager = Object.FindObjectOfType<hakmanager>();

        hakmanager.kalpolustur();


    }


    public void kareolustur()
    {
        for (int i = 0;i<25;i++)
        {
            GameObject kare = Instantiate(kareler,karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());

            karelerDizisi[i] = kare;

        }

        bolumdegerlerinitextyazdir();
        StartCoroutine(DoFadeRoutine());
        Invoke("sorupaneliniac", 2f);
        hakolustur();
        
    }


    void oyunbitti()
    {
        butonaBasilsinmi = false;
        sonucPanel.GetComponent<RectTransform>().DOScale(1.0f, 0.3f).SetEase(Ease.OutBack);

    }

    void ButonaBasildi()
    {
       if (butonaBasilsinmi)
        {
            butondegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            gecerlikare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            sonucdogrumu();
        }
        

    }


    private void Start()
    {
        sorupaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        Invoke("kareolustur", 0.7f);
        kalpolusturma();
        


        
    }


    void sonucdogrumu()
    {
        if (butondegeri == dogrusonuc)
        {
            gecerlikare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerlikare.transform.GetChild(0).GetComponent<Text>().enabled = false;

            Puanmanager.puanArttir(SorununZorlukSeviyesi);

            bolumDegerleriList.RemoveAt(kacincisoru);

           
            sorupaneliniac();
        }
        else
        {
            kalanHak--;
            hakmanager.HaklariKontrolEt(kalanHak);
        }

        if(kalanHak<=0)
        {
            oyunbitti();
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
        SoruSor();
        sorupaneli.GetComponent<RectTransform>().DOScale(1.0f, 0.3f).SetEase(Ease.OutBack);
        butonaBasilsinmi = true;
    }

   void SoruSor()
    {

        bolensayi = Random.Range(2, 11);
        
        kacincisoru = Random.Range(0, bolumDegerleriList.Count);

        dogrusonuc = bolumDegerleriList[kacincisoru];
        
        bolunensayi = bolensayi * dogrusonuc;

        if (bolunensayi <= 40)
        {
            SorununZorlukSeviyesi = "kolay";
        }
        else if (bolunensayi > 40 && bolunensayi <= 80)
        {
            SorununZorlukSeviyesi = "orta";
        }
        else
        {
            SorununZorlukSeviyesi = "zor";
        }


        sorutext.text = bolunensayi.ToString() + ":" + bolensayi;



    }


}
