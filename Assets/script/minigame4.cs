using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class minigame4 : MonoBehaviour
{
    private static string password = "delete";

    public TMP_InputField inputField;
    public bool game_start = false;


    void Update(){
        if(inputField.text == password){
            game_start = false;
            gameObject.SetActive(false);
            Gamemanager.instance.view += 10;
            Gamemanager.instance.chat.delete_bad_chat();
            Soundmanager.Instance.Playsound("s");
        }
    }
    public void SpawnRandomButton()
    {
        inputField.text = "";
        game_start = true;
        RectTransform buttonRect = gameObject.GetComponent<RectTransform>();

        float minX = -455f;
        float maxX = 255f;
        float minY = -310f;
        float maxY = 235f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
        game_start = true;
    }
}
