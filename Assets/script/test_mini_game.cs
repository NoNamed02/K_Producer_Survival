using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_mini_game : MonoBehaviour
{

    [SerializeField]
    private GameObject T1;
    [SerializeField]
    private GameObject T2;

    public bool check1, check2;

    void Start()
    {
        T1 = gameObject.transform.GetChild(0).gameObject;
        T2 = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                GameObject check = hit.transform.gameObject;
                if (check.name == "T1")
                {
                    SpriteRenderer sr = T1.GetComponent<SpriteRenderer>();
                    if (sr != null)
                    {
                        sr.color = new Color(1, 0, 0); // 빨간색으로 변경
                    }
                    check1 = true;
                }
                if (check.name == "T2")
                {
                    SpriteRenderer sr = T2.GetComponent<SpriteRenderer>();
                    if (sr != null)
                    {
                        sr.color = new Color(1, 0, 0); // 빨간색으로 변경
                    }
                    check2 = true;
                }
            }
        }

        if (check1 && check2)
        {
            Gamemanager.instance.view += 10;
            
            Gamemanager.instance.chat.delete_bad_chat();
            
            Soundmanager.Instance.Playsound("s");
            Destroy(gameObject);
        }
    }
}
