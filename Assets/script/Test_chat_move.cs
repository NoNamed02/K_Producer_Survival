using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test_chat_move : MonoBehaviour
{
    public int boxPosition = 0;
    private Transform position;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject self;

    public bool is_bad;

    private TextMeshPro textMeshPro;
    public TextAsset txt;

    string[,] Sentence;
    int rowSize, colSize;

    private bool is_click = false;

    void Start()
    {
        string currentText = txt.text.Trim();
        string[] lines = currentText.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        rowSize = lines.Length;
        colSize = lines[0].Split('\t').Length;

        Sentence = new string[rowSize, colSize];

        for (int i = 0; i < rowSize; i++)
        {
            string[] columns = lines[i].Split('\t');
            for (int j = 0; j < colSize; j++)
            {
                if (j < columns.Length)
                {
                    Sentence[i, j] = columns[j];
                }
                else
                {
                    Sentence[i, j] = "";
                }
            }
        }
        GameObject Text = transform.GetChild(0).gameObject;
        textMeshPro = Text.GetComponent<TextMeshPro>();

        int chat_num = Random.Range(1, 20);
        int is_badchat = Random.Range(0, 10);

        if (is_badchat <= 3) /////////////////////////////////////////////////////
        {
            is_bad = true;
            textMeshPro.text = Sentence[chat_num + 1, 2];
            StartCoroutine(ChangeColorTemporarily());
        }
        else
        {
            is_bad = false;
            textMeshPro.text = Sentence[chat_num + 1, 0];
        }

        position = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        position.position = new Vector3(6.8f, 3.0f, position.position.z);

        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;

        if (textMeshPro != null)
        {
            Color textColor = textMeshPro.color;
            textColor.a = 0f;
            textMeshPro.color = textColor;
            StartCoroutine(FadeIn_chat());
        }

        StartCoroutine(FadeIn());
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator FadeIn()
    {
        float duration = 1.0f; // 페이드 인 시간
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Color color = spriteRenderer.color;
            color.a = Mathf.Clamp01(elapsed / duration);
            spriteRenderer.color = color;
            yield return null;
        }

        // 완전히 투명하지 않게 설정
        Color finalColor = spriteRenderer.color;
        finalColor.a = 1f;
        spriteRenderer.color = finalColor;
    }

    IEnumerator FadeOut()
    {
        float duration = 1.0f; // 페이드 아웃 시간
        float elapsed = 0.0f;

        // 글자 페이드 아웃 시작
        if (textMeshPro != null)
        {
            StartCoroutine(FadeOutText());
        }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Color color = spriteRenderer.color;
            color.a = Mathf.Clamp01(1 - (elapsed / duration));
            spriteRenderer.color = color;
            yield return null;
        }

        if (is_bad)
        {
            if(Gamemanager.instance.is_game_end == false){
                Soundmanager.Instance.Playsound("f");
                Gamemanager.instance.view -= 20;
            }

        }
        Destroy(gameObject); // 오브젝트 파괴
    }

    IEnumerator FadeOutText()
    {
        float duration = 1.0f; // 페이드 아웃 시간
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            if (textMeshPro != null)
            {
                Color textColor = textMeshPro.color;
                textColor.a = Mathf.Clamp01(1 - (elapsed / duration));
                textMeshPro.color = textColor;
            }
            yield return null;
        }

        // 완전히 투명하게 설정
        if (textMeshPro != null)
        {
            Color finalTextColor = textMeshPro.color;
            finalTextColor.a = 0f;
            textMeshPro.color = finalTextColor;
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f);

            yield return StartCoroutine(MoveDown());
        }
    }

    IEnumerator MoveDown()
    {
        float duration = 1.0f;
        float elapsed = 0.0f;
        Vector3 startPos = position.position;
        Vector3 endPos = new Vector3(startPos.x, startPos.y - 1.5f, startPos.z);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            position.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            yield return null;
        }

        if (boxPosition == 0)
        {
            Instantiate(self, position.position, position.rotation);
        }
        else if (boxPosition == 3)
        {
            StartCoroutine(FadeOut()); // 페이드 아웃 시작
            yield break; // 코루틴 종료
        }

        position.position = endPos;
        boxPosition++;
    }

    IEnumerator FadeIn_chat()
    {
        float duration = 1.0f; // 페이드 인 시간
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);

            // TextMeshPro의 투명도 조절
            if (textMeshPro != null)
            {
                Color textColor = textMeshPro.color;
                textColor.a = alpha;
                textMeshPro.color = textColor;
            }
            yield return null;
        }

        // 완전히 투명하지 않게 설정
        if (textMeshPro != null)
        {
            Color finalTextColor = textMeshPro.color;
            finalTextColor.a = 1f;
            textMeshPro.color = finalTextColor;
        }
    }

    IEnumerator ChangeColorTemporarily()
    {
        if (textMeshPro != null)
        {
            Color originalColor = textMeshPro.color;
            textMeshPro.color = Color.red;

            yield return new WaitForSeconds(1f);

            float fadeDuration = 0.3f; // 페이드 아웃 시간
            float elapsed = 0.0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                textMeshPro.color = Color.Lerp(Color.red, originalColor, elapsed / fadeDuration);
                yield return null;
            }

            textMeshPro.color = originalColor;
        }
    }

    public void delete_bad_chat()
    {
        if (!is_click)
        {
            Soundmanager.Instance.Playsound("d");
            int like = Random.Range(1, 3);
            int kr_or_jp = Random.Range(0, 2);
            if (kr_or_jp == 0)
                textMeshPro.text = "(삭제됨)";
            else
                textMeshPro.text = "(削除済み)";
            if (is_bad == true)
            {
                Gamemanager.instance.score += 100;;
                Gamemanager.instance.view += like;
                is_bad = false;
            }
            else
            {
                Gamemanager.instance.view -= like * 2;
            }
            is_click = true;
        }
    }
}
