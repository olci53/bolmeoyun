using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonucmanager : MonoBehaviour
{
   public void yenidenBasla()
    {
        SceneManager.LoadScene("gameLevel");
    }


    public void anaMenu()
    {
        SceneManager.LoadScene("menuLevel");
    }


}
