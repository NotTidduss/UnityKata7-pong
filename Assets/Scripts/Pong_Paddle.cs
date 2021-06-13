using UnityEngine;

public class Pong_Paddle : MonoBehaviour
{
    private bool moveUpEnabled;
    private bool moveDownEnabled;
    private float movementSpeed;

    void Start() {
        moveUpEnabled = true;
        moveDownEnabled = true;
        movementSpeed = PlayerPrefs.GetFloat("kata7_paddleMovementSpeed");
    } 

    public void moveUp() {
        if (moveUpEnabled) {
            move(movementSpeed);
            moveDownEnabled = true;
        }
    }

    public void moveDown() {
        if (moveDownEnabled) {
            move(-movementSpeed);
            moveUpEnabled = true;
        }
    }

    private void move(float movement) => transform.Translate(0, movement, 0);

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Ceiling":
                moveUpEnabled = false;
                break;
            case "Floor":
                moveDownEnabled = false;
                break;
        }
    }
}
