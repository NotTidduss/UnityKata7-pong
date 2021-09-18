using UnityEngine;
using UnityEngine.SceneManagement;

public class Pong_Init : MonoBehaviour
{
    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene("1_Pong");
    }

    private void initializePlayerPrefs() {
        PlayerPrefs.DeleteAll();

        // pong_winsP1 - the sum of Player 1's wins in the session
        PlayerPrefs.SetInt("pong_winsP1", 0);
        // pong_winsP2 - the sum of Player 2's wins in the session
        PlayerPrefs.SetInt("pong_winsP2", 0);
    }
}
