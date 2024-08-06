using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class minigame5 : MonoBehaviour
{
    public string password = "";

    public TMP_InputField inputField;

    public TMP_Text Textinput;
    public TMP_Text Text1;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public bool game_start = false;

    public int check;

    void Start(){
        SpawnRandomButton();
    }

    void Update(){
        Textinput.text = "Input\n" + "[" + password + "]";
        if(inputField.text == password){
            password_make();
            inputField.text = "";
            check += 1;
        }
        if(check == 1){
            Text1.text = "[O]";
            Text2.text = "[ ]";
            Text3.text = "[ ]";
        }
        if(check == 2){
            Text1.text = "[O]";
            Text2.text = "[O]";
            Text3.text = "[ ]";
        }
        if(check == 3){
            Text1.text = "[O]";
            Text2.text = "[O]";
            Text3.text = "[O]";
        }

        if(check >= 3){
            game_start = false;
            Soundmanager.Instance.Playsound("s");
            Gamemanager.instance.view += 10;
            Gamemanager.instance.chat.delete_bad_chat();
            gameObject.SetActive(false);
        }
    }
    public void SpawnRandomButton()
    {
        check = 0;
        inputField.text = "";
        Text1.text = "[ ]";
        Text2.text = "[ ]";
        Text3.text = "[ ]";

        password_make();

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

    public void password_make(){
        int random = Random.Range(0,7);
        if(random == 0)
            password = "a";
        else if(random == 1)
            password = "b";
        else if(random == 2)
            password = "c";
        else if(random == 3)
            password = "d";
        else if(random == 4)
            password = "e";
        else if(random == 5)
            password = "f";
        else if(random == 6)
            password = "g";
    }
}
