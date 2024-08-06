using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class view_score : MonoBehaviour
{
    
    public TMP_Text textMeshPro;


    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Score : " + Gamemanager.instance.score;
    }
}
