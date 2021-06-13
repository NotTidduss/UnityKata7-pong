using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    [Header("Global Game Settings")]
    [SerializeField] private float paddleMovementSpeed = 0.1f;
    [SerializeField] private float newMatchWaitTime = 2f;

    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene("1_Pong");
    }

    private void initializePlayerPrefs() {
        PlayerPrefs.DeleteAll();

        // kata7_winsP1 - the sum of Player 1's wins in the session
        PlayerPrefs.SetInt("kata7_winsP1", 0);
        // kata7_winsP2 - the sum of Player 2's wins in the session
        PlayerPrefs.SetInt("kata7_winsP2", 0);

        // kata7_paddleMovementSpeed - the movement speed the paddles, higher means faster
        PlayerPrefs.SetFloat("kata7_paddleMovementSpeed", paddleMovementSpeed);
        // kata7_defaultGameRefreshRate - the 'tick' speed the game, lower means faster
        PlayerPrefs.SetFloat("kata7_newMatchWaitTime", newMatchWaitTime);
    }
}
