using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    public GameObject objectToActivate; // 활성화할 오브젝트

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}