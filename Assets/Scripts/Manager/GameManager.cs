using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public Variables
    public static GameManager instance;

    // Inspector Variables
    [Header("References")]
    [SerializeField] TextMeshProUGUI player1ScoreText;
    [SerializeField] TextMeshProUGUI player2ScoreText;

    // Private Variables
    /// <summary>
    /// Player 1 total score
    /// </summary>
    int Player1score;
    /// <summary>
    /// Player 2 total score
    /// </summary>
    int Player2score;

    private void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Increase tthe score of the player who scored
    /// </summary>
    /// <param name="score"> The score value by which total score should be increased </param>
    public void IncreaseScore(int score)
    {
        if(TurnManager.instance.currPlayer == Players.player1)
        {
            // increasing Player 1 score
            Player1score += score;
            // Updating score in UI
            player1ScoreText.text = "Score: " + Player1score.ToString();
        }
        else
        {
            // icreasing player 2 score
            Player2score += score;
            // Updating in UI
            player2ScoreText.text = "Score: " + Player2score.ToString();
        }
    }

    /// <summary>
    /// Restarts the current scene
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
