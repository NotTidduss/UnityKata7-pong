using UnityEngine;
using UnityEngine.SceneManagement;

public class Pong_System : MonoBehaviour
{
    [Header ("Scene Names")]
    public string pongSceneName = "1_Pong";

    [Header("Pong Settings")]
    public float paddleMovementSpeed = 0.1f;
    public float newMatchWaitTime = 2f;
    public float ballMovementX = 0.015f;
    public float ballMovementYMin = 0.005f;
    public float ballMovementYMax = 0.04f;

    [Header("Keybinding")]
    public KeyCode p1_MoveUp = KeyCode.W;
    public KeyCode p1_MoveDown = KeyCode.S;
    public KeyCode p2_MoveUp = KeyCode.UpArrow;
    public KeyCode p2_MoveDown = KeyCode.DownArrow;
    public KeyCode pause = KeyCode.Space;


    public void loadPongScene() => SceneManager.LoadScene(pongSceneName);
}
