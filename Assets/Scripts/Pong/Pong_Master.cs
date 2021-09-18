using System.Collections;
using UnityEngine;

public class Pong_Master : MonoBehaviour
{
    [Header("Scene References")]
    public Pong_System sys;
    [SerializeField] private Pong_UI ui;
    [SerializeField] private Pong_Paddle paddle_P1;
    [SerializeField] private Pong_Paddle paddle_P2;
    [SerializeField] private Pong_Ball ball;


    private bool isPaused;

    void Start() {
        // prepare private variables
        isPaused = false;

        // start Game
        ui.initialize();
        StartCoroutine("CheckForInput");
    }

    IEnumerator CheckForInput() {
        while (true) {
            if (!isPaused) {
                if (Input.GetKey(sys.p1_MoveUp)) paddle_P1.moveUp();
                if (Input.GetKey(sys.p1_MoveDown)) paddle_P1.moveDown();
                if (Input.GetKey(sys.p2_MoveUp)) paddle_P2.moveUp();
                if (Input.GetKey(sys.p2_MoveDown)) paddle_P2.moveDown();
            }

            if (Input.GetKeyUp(sys.pause)) pause();

            yield return null;
        }
    }

    IEnumerator StartNextMatch() {
        yield return new WaitForSeconds(sys.newMatchWaitTime);
        sys.loadPongScene();
    }

    public void finishMatch(int winner) {
        ui.setFinishTexts(winner);
        StartCoroutine("StartNextMatch");
    }

    public int getCurrentWinner() => PlayerPrefs.GetInt("pong_winsP1") > PlayerPrefs.GetInt("pong_winsP2") ? 1 : 2;

    private void pause() {
        isPaused = !isPaused;
        ball.syncPause(isPaused);
    }
}
