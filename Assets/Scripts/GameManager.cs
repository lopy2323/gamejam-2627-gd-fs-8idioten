using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static int winnerPlayer;
    public static int player1Score;
    public static int player2Score;

    public void EndGame(int winner, int score1, int score2)
    {
        winnerPlayer = winner;
        player1Score = score1;
        player2Score = score2;

        SceneManager.LoadScene(2);
    }
}
