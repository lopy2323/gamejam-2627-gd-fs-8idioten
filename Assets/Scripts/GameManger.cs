using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    [SerializeField] private TMP_Text scoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    public static int winnerPlayer;
    public static int finalPlayer1Score;
    public static int finalPlayer2Score;

    [SerializeField] private Health player1Health;
    [SerializeField] private Health player2Health;

    [SerializeField] private SpaceShipMovment player1Movement;
    [SerializeField] private SpaceShipMovment player2Movement;

    private Vector3 player1StartPosition;
    private Vector3 player2StartPosition;

    private void Start()
    {
        player1StartPosition = player1Movement.transform.position;
        player2StartPosition = player2Movement.transform.position;
    }
    public void PlayerDied(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player2Score++;
        }
        else if (playerNumber == 2)
        {
            player1Score++;
        }

        UpdateScore();

        if (player1Score >= 3)
        {
            EndGame(1);
        }
        else if (player2Score >= 3)
        {
            EndGame(2);
        }
        else
        {
            StartNewRound();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = player1Score + " - " + player2Score;
    }

    private void StartNewRound()
    {
        player1Movement.ResetMovement(player1StartPosition);
        player2Movement.ResetMovement(player2StartPosition);

        player1Health.ResetHealth();
        player2Health.ResetHealth();
    }

    private void EndGame(int winner)
    {
        winnerPlayer = winner;
        finalPlayer1Score = player1Score;
        finalPlayer2Score = player2Score;

        SceneManager.LoadScene(2);
    }
}
