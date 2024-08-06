using System.Collections;
using UnityEngine;
using TMPro;

public class TextMeshProFadeIn : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    public TextAsset txt;

    string[,] Sentence;
    int rowSize, colSize;

    [SerializeField]
    private bool is_bad;

    private Test_chat_move chat;


    void Start()
    {
        /*
        GameObject parent = transform.parent.gameObject;
        chat = parent.GetComponent<Test_chat_move>();

        Random.InitState(System.DateTime.Now.Millisecond + gameObject.GetInstanceID());
        textMeshPro = GetComponent<TextMeshPro>();

        // excel file
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

        int chat_num = Random.Range(1, 20);
        int is_badchat = Random.Range(0, 10);
        if (is_badchat <= 3)
        {
            textMeshPro.text = Sentence[chat_num + 1, 2];
            is_bad = true;
            StartCoroutine(ChangeColorTemporarily());
        }
        else
        {
            textMeshPro.text = Sentence[chat_num + 1, 0];
            is_bad = false;
        }
        */

        if (textMeshPro != null)
        {
            Color textColor = textMeshPro.color;
            textColor.a = 0f;
            textMeshPro.color = textColor;
            StartCoroutine(FadeIn());
        }
    }

    /*
    IEnumerator ChangeColorTemporarily()
    {
        if (textMeshPro != null)
        {
            Color originalColor = textMeshPro.color;
            textMeshPro.color = Color.red;

            yield return new WaitForSeconds(1f);

            float fadeDuration = 1.0f; // 페이드 아웃 시간
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
    */

    IEnumerator FadeIn()
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
}
