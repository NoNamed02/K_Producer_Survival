using UnityEngine;
using UnityEngine.UI;

public class view_value : MonoBehaviour
{
    public Slider Slider;
    

    void Start()
    {
        Gamemanager.instance.view = 10;
        Slider.maxValue = 100;
    }

    void Update()
    {
        Slider.value = Gamemanager.instance.view;
    }
}