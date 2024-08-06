using System.Collections;
using UnityEngine;

public class SequentialActivation : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    public float delayBetweenActivations = 1f; // 활성화 사이의 대기 시간

    public int count = 0; // 활성화된 오브젝트 수
    public GameObject loading; // 4번째 오브젝트가 활성화된 후 나타나는 오브젝트

    public AudioSource musicSource; // 음악을 재생할 AudioSource
    public AudioClip music1; // 1-3번 오브젝트 활성화 시 재생할 음악
    public AudioClip music2; // 4번째 오브젝트 활성화 시 재생할 음악

    private void Start()
    {
        StartCoroutine(ActivateObjectsSequentially());
    }

    private IEnumerator ActivateObjectsSequentially()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(delayBetweenActivations);
            count++;

            // 음악 재생 제어
            if (count == 4)
            {
                // 4번째 오브젝트 활성화 시 music2 재생
                musicSource.clip = music2;
                musicSource.Play();

                // 3초 후에 로딩 활성화
                StartCoroutine(ActivateLoadingAfterDelay(3f));
            }
            else
            {
                // 1-3번 오브젝트 활성화 시 music1 재생
                if (!musicSource.isPlaying || musicSource.clip != music1)
                {
                    musicSource.clip = music1;
                    musicSource.Play();
                }
            }
        }
    }

    private IEnumerator ActivateLoadingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        loading.SetActive(true);
    }
}
