using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pong_Master : MonoBehaviour
{
    [Header("Pong References")]
    [SerializeField] private Pong_Input controls;
    [SerializeField] private Pong_Paddle paddle_P1;
    [SerializeField] private Pong_Paddle paddle_P2;
    [SerializeField] private Pong_Ball ball;

    [Header("Score References")]
    [SerializeField] private TMPro.TextMeshPro winsText_P1;
    [SerializeField] private TMPro.TextMeshPro winsText_P2;
    [SerializeField] private TMPro.TextMeshPro finishText;

    private bool isPaused;

    void Start() {
        isPaused = false;
        winsText_P1.text = PlayerPrefs.GetInt("kata7_winsP1").ToString();
        winsText_P2.text = PlayerPrefs.GetInt("kata7_winsP2").ToString();
        finishText.gameObject.SetActive(false);

        StartCoroutine("CheckForInput");
    }

    IEnumerator CheckForInput() {
        while (true) {
            if (!isPaused) {
                if (Input.GetKey(controls.p1_MoveUp)) paddle_P1.moveUp();
                if (Input.GetKey(controls.p1_MoveDown)) paddle_P1.moveDown();
                if (Input.GetKey(controls.p2_MoveUp)) paddle_P2.moveUp();
                if (Input.GetKey(controls.p2_MoveDown)) paddle_P2.moveDown();
            }

            if (Input.GetKeyUp(controls.pause)) pause();

            yield return null;
        }
    }

    IEnumerator StartNextMatch() {
        for (int i = 0; i < 1; i++) yield return new WaitForSeconds(PlayerPrefs.GetFloat("kata7_newMatchWaitTime"));
        SceneManager.LoadScene("1_Pong");
    }

    /*
        Determine winner, update scores and start StartNextMatch coroutine.
        
        @param winner - 1 = Player 1, 2 = Player 2
    */
    public void finishMatch(int winner) {
        finishText.gameObject.SetActive(true);
        switch (winner) {
            case 1:
                int winsP1 = PlayerPrefs.GetInt("kata7_winsP1");
                winsP1++;
                winsText_P1.text = winsP1.ToString();
                PlayerPrefs.SetInt("kata7_winsP1", winsP1);
                finishText.text = "P1 WINS!";
                break;
            case 2:
                int winsP2 = PlayerPrefs.GetInt("kata7_winsP2");
                winsP2++;
                winsText_P2.text = winsP2.ToString();
                PlayerPrefs.SetInt("kata7_winsP2", winsP2);
                finishText.text = "P2 WINS!";
                break;
        }
        StartCoroutine("StartNextMatch");
    }

    /*
        Retrieve current winner based on sum of wins.

        @return currently winning player.
    */
    public int getCurrentWinner() => PlayerPrefs.GetInt("kata7_winsP1") > PlayerPrefs.GetInt("kata7_winsP2") ? 1 : 2;

    private void pause() {
        isPaused = !isPaused;
        ball.syncPause(isPaused);
    }
}
