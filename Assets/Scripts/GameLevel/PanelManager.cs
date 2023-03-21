using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 2.0f);
    }



}
