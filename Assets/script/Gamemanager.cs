using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject bad_chat;
    public Test_chat_move chat;

    public int view;
    public static Gamemanager instance;
    public GameObject[] minigame = new GameObject[5];

    public int game_count;

    public minigame2 minigame2;
    

    public minigame3 minigame3;
    public minigame4 minigame4;
    public minigame5 minigame5;
    public GameObject Gameover;

    public GameObject Loading;

    public bool is_game_end;

    public int score = 0;
    private int i = 0;

    public int random;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update()
    {   
        random = Random.Range(0, game_count);
        if(!is_game_end){

            i++;
            if(i >= 30){
                score += 1;
                i = 0;
            }
        }
        if(view <= 0){
                Soundmanager.Instance.Sound.Stop(); 
                Gameover.SetActive(true);
            }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                Test_chat_move hitChat = hit.transform.GetComponent<Test_chat_move>();

                if (hitChat != null)
                {
                    bad_chat = hit.transform.gameObject;
                    Debug.Log(bad_chat.name);
                    chat = hitChat;

                    if (chat.is_bad)
                    {
                        
                        if(random == 0)
                            InstantiateRandomly(minigame[0]);
                        else if(random == 1){
                            minigame2.gameObject.SetActive(true);
                            minigame2.SpawnRandomButton();
                        }
                        else if(random == 2){
                            minigame3.gameObject.SetActive(true);
                            minigame3.SpawnRandomButton();
                        }
                        else if(random == 3){
                            minigame4.gameObject.SetActive(true);
                            minigame4.SpawnRandomButton();
                        }
                        else if(random == 4){
                            minigame5.gameObject.SetActive(true);
                            minigame5.SpawnRandomButton();
                        }
                    }
                }
            }
        }

        if (Gamemanager.instance.view >= 100)
        {
            is_game_end = true;
            Loading.SetActive(true);
            Gamemanager.instance.view = 100;
        }
    }

    void InstantiateRandomly(GameObject obj)
    {
        float x = Random.Range(-4.5f, 3.3f);
        float y = Random.Range(-3.3f, 3.3f);
        Vector3 randomPosition = new Vector3(x, y, 0);

        Instantiate(obj, randomPosition, Quaternion.identity);
    }
}
