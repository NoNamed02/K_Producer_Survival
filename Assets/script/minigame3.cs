using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minigame3 : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public int count;
    public bool game_start = false;

    void Start(){
        GameObject sub = transform.GetChild(0).gameObject;
        textMeshPro = sub.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = count.ToString();
        if(count >= 10 && game_start){
            game_start = false;
            gameObject.SetActive(false);
            Gamemanager.instance.view += 10;
            Gamemanager.instance.chat.delete_bad_chat();
            Soundmanager.Instance.Playsound("s");
        }
    }

    public void push_btn(){
        Soundmanager.Instance.Playsound("main_btn");
        count++;
    }

    public void SpawnRandomButton()
    {
        count = 0;
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
