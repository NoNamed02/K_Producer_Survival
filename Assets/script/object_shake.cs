using System.Collections;
using UnityEngine;

public class ContinuousObjectShake : MonoBehaviour
{
    public float magnitude = 0.1f; // 떨림 강도
    public float frequency = 0.05f; // 떨림 주기

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(ContinuousShake());
    }

    private IEnumerator ContinuousShake()
    {
        while (true)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            yield return new WaitForSeconds(frequency);
        }
    }
}
