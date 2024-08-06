using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{
    public Slider load;
    public string scence_name;
    public TMP_Text Text;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(scence_name);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        float minLoadingTime = 3.0f; // 최소 로딩 시간 3초
        bool loadingComplete = false;

        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                load.value = Mathf.Lerp(load.value, op.progress, timer);
                if (load.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                load.value = Mathf.Lerp(load.value, 1f, timer);
                if (load.value >= 1.0f)
                {
                    load.value = 1.0f;
                    loadingComplete = true;
                }
            }

            if (loadingComplete && timer >= minLoadingTime)
            {
                Text.text = "Click to next stage!";
                if (Input.GetMouseButtonDown(0))
                {
                    op.allowSceneActivation = true;
                }
            }
            else{
                Text.text = "Ready to next stage.....";
            }
        }
    }
}
