using System.Collections;
using UnityEngine;

public class Pong_Ball : MonoBehaviour
{
    [Header ("Master Reference")]
    public Pong_Master master;

    private Vector3 ballMovement;
    private float currentMovementX;
    private float currentMovementY;
    private bool isPaused;

    /*
        Initialize private variables,
        randomize Y movement,
        set starting position to losing side (default P1 side),
        start coroutine for moving.
    */
    void Start() {
        // prepare private variables: randomize Y movement, change starting position based on current winner
        ballMovement.x = master.sys.ballMovementX;
        ballMovement.y = Random.Range(master.sys.ballMovementYMin, master.sys.ballMovementYMax);

        if (master.getCurrentWinner() == 1) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            ballMovement = -ballMovement;
        } 

        currentMovementX = ballMovement.x;
        currentMovementY = ballMovement.y;
        isPaused = false;

        StartCoroutine("MoveBall");
    }

    IEnumerator MoveBall() {
        while (true) {
            if (!isPaused) transform.Translate(ballMovement);
            yield return null;
        }
    }

    /*
        Synchronizes this script's pause setting with the pause setting from the Master script.

        @param masterPaused - the current pause setting in the Master script.
    */
    public void syncPause(bool masterPaused) => isPaused = masterPaused;

    /*
        Determines the winner of match based on which wall was hit.

        @param wallName - the name of the wall in the scene hierarchy that the ball collided with
        @return 2 if left was hit and 1 if right wall was hit
    */
    private int getWinner(string wallName) => wallName.Contains("left") ? 2 : 1;

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":
                currentMovementX = ballMovement.x;
                currentMovementX += currentMovementX > 0 ? 0.002f : -0.002f;
                ballMovement.x = -currentMovementX;
                break;
            case "Ceiling": case "Floor":
                currentMovementY = ballMovement.y;
                ballMovement.y = -currentMovementY;
                break;
            case "Wall":
                master.finishMatch(getWinner(collision.gameObject.name.ToLower()));
                break;
        }
    }
}
