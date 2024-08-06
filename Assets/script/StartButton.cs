using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    public GameObject startbutton1; //first button image
    public GameObject startbutton2;//secondary


public void changeButton()
    {
        startbutton1.SetActive(false);
        startbutton2.SetActive(true);
    }

public void rechangebutton()
    {   
        startbutton1.SetActive(true);
        startbutton2.SetActive(false);
    }
}