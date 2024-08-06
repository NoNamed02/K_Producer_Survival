using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit_game()
    {
        // 게임 종료
        Application.Quit();
        
        // 유니티 에디터에서는 종료되지 않으므로 로그 메시지 출력
        #if UNITY_EDITOR
        Debug.Log("Game is exiting");
        #endif
    }
}