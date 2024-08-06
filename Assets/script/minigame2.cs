using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minigame2 : MonoBehaviour
{
        public TMP_Text textMeshPro;
        
        public int value; // 가위바위보 값
        public int cpu_Value; // ai값

        void Start(){
            cpu_Value = Random.Range(0,3); // 0 r / 1 s / 2 p

            GameObject sub = transform.GetChild(0).gameObject;
            textMeshPro = sub.GetComponent<TMP_Text>();
            
        }

        void Update(){
            if(cpu_Value == 0)
                textMeshPro.text = "Rock";
            else if(cpu_Value == 1)
                textMeshPro.text = "scissors";
            else if(cpu_Value == 2)
                textMeshPro.text = "paper";
        }

        //rock-paper-scissors
        public void check(){
            if(cpu_Value == 0 && value == 2 ||
                cpu_Value == 1 && value == 0 ||
                cpu_Value == 2 && value == 1){
                Gamemanager.instance.view += 10;
                Soundmanager.Instance.Playsound("s");
                Gamemanager.instance.chat.delete_bad_chat();
                gameObject.SetActive(false);
                
            }
            else{
                Gamemanager.instance.view -= 10;
                Soundmanager.Instance.Playsound("f");
                gameObject.SetActive(false);
            }
        }

        public void change_value_r(){
            value = 0;
            check();
        }
        public void change_value_s(){
            value = 1;
            check();
        }
        public void change_value_p(){
            value = 2;
            check();
        }

    public void SpawnRandomButton()
    {
        cpu_Value = Random.Range(0,3); // 0 r / 1 s / 2 p
        RectTransform buttonRect = gameObject.GetComponent<RectTransform>();

        float minX = -455f;
        float maxX = 255f;
        float minY = -310f;
        float maxY = 235f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}
