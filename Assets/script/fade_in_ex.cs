using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect_ex : MonoBehaviour
{
    public Image image;

    private void OnEnable()
    {
        if (image != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        // 스케일 초기화
        Vector3 initialScale = new Vector3(2f, 2f, 2f);
        Vector3 finalScale = new Vector3(1f, 1f, 1f);
        image.transform.localScale = initialScale;

        float elapsedTime = 0f;
        float fadeDuration = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            // 페이드 인 효과
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            image.color = color;
            // 스케일 줄이는 효과
            image.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / fadeDuration);
            yield return null;
        }

        color.a = 1f;
        image.color = color;
        image.transform.localScale = finalScale;
    }
}
