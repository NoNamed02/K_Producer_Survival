using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    private static Soundmanager instance;
    public static Soundmanager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<Soundmanager>();
                singletonObject.name = typeof(Soundmanager).ToString() + " (Singleton)";
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
    public AudioSource Sound;
    public AudioClip main_btn;
    public AudioClip s;
    public AudioClip f;
    public AudioClip d;


    public string sound_name;

    public void Playsound(string n){
        sound_name = n;
        switch(sound_name){
            case "main_btn":
                Sound.clip = main_btn;
                break;
            
            case "s":
                Sound.clip = s;
                break;  

            case "f":
                Sound.clip = f;
                break; 
                
            case "d":
                Sound.clip = d;
                break; 
        }
        Sound.Play();
    }
}
