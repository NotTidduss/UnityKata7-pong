using UnityEngine;

public class Pong_UI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMPro.TextMeshPro winsText_P1;
    [SerializeField] private TMPro.TextMeshPro winsText_P2;
    [SerializeField] private TMPro.TextMeshPro finishText;

    public void initialize() {
        winsText_P1.text = PlayerPrefs.GetInt("pong_winsP1").ToString();
        winsText_P2.text = PlayerPrefs.GetInt("pong_winsP2").ToString();
        finishText.gameObject.SetActive(false);
    }

    public void setFinishTexts(int winner) {
        finishText.gameObject.SetActive(true);
        switch (winner) {
            case 1:
                int winsP1 = PlayerPrefs.GetInt("pong_winsP1");
                winsP1++;
                winsText_P1.text = winsP1.ToString();
                PlayerPrefs.SetInt("pong_winsP1", winsP1);
                finishText.text = "P1 WINS!";
                break;
            case 2:
                int winsP2 = PlayerPrefs.GetInt("pong_winsP2");
                winsP2++;
                winsText_P2.text = winsP2.ToString();
                PlayerPrefs.SetInt("pong_winsP2", winsP2);
                finishText.text = "P2 WINS!";
                break;
        }
    }
}
