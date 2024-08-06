using UnityEngine;

public class VerticalOscillation : MonoBehaviour
{
    public float amplitude = 0.5f; // 위아래로 움직이는 범위
    public float frequency = 1f;   // 움직이는 속도

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        Gamemanager.instance.game_count = 5;
    }

    private void Update()
    {
        // yPosition은 진폭과 주기를 사용하여 계산된 y 위치입니다.
        float yPosition = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, yPosition, startPosition.z);
    }
}
