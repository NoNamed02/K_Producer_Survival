using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_btn : MonoBehaviour
{
    public GameObject Loading;
    

    public void start_game(){
        Soundmanager.Instance.Playsound("main_btn");
        Loading.SetActive(true);
    }
}
