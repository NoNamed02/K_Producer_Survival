using UnityEngine;

public class ScaleOscillation : MonoBehaviour
{
    public float minScale = 1f;       // 최소 스케일
    public float maxScale = 1.3f;     // 최대 스케일
    public float speed = 1f;          // 스케일 변화 속도

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1));
        transform.localScale = initialScale * scale;
    }
}
