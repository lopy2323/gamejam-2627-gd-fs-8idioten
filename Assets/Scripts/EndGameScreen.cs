using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        winnerText.text = "PLAYER " + GameManager.winnerPlayer + " WINS!";

        scoreText.text =
            GameManager.finalPlayer1Score +
            " - " +
            GameManager.finalPlayer2Score;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        MainMenu();
    }
}
