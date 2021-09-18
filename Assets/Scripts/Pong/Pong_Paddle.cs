using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    [Header ("Master Reference")]
    public Pong_Master master;

    private bool moveUpEnabled;
    private bool moveDownEnabled;
    private float movementSpeed;

    void Start() {
        moveUpEnabled = true;
        moveDownEnabled = true;
        movementSpeed = master.sys.paddleMovementSpeed;
    } 

    public void moveUp() {
        if (moveUpEnabled) {
            move(movementSpeed);
            if (!moveDownEnabled) moveDownEnabled = true;
        }
    }

    public void moveDown() {
        if (moveDownEnabled) {
            move(-movementSpeed);
            if (!moveUpEnabled) moveUpEnabled = true;
        }
    }

    private void move(float movement) => transform.Translate(0, movement, 0);

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Ceiling": moveUpEnabled = false; break;
            case "Floor": moveDownEnabled = false; break;
        }
    }
}
