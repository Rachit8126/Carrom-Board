using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public enum Players
{
    player1,
    player2,
}

public class TurnManager : MonoBehaviour
{
    // Public Variables
    public static TurnManager instance;

    /// <summary>
    /// The player playing currently
    /// </summary>
    [HideInInspector] public Players currPlayer;
    /// <summary>
    /// Checks if the player has scored or not.
    /// </summary>
    [HideInInspector] public bool scored = false;

    // Inspector Variables
    [Header("References")]
    [SerializeField] GameObject striker1;
    [SerializeField] GameObject striker2;
    [SerializeField] Slider striker1Slider;

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);

        // setting the initial player as player 1
        currPlayer = Players.player1;
    }

    public void ChangeTurn()
    {
        // checking if the current player scored or not
        if (scored)
        {
            // setting scored bool to falsee so that the player does not get second chane if he didn't score
            scored = false;

            // giving chance to same player
            return;
        }
        else
        {
            // Switching the player's turn
            if (currPlayer == Players.player1)
            {
                currPlayer = Players.player2;
                Player2Turn();
            }
            else
            {
                currPlayer = Players.player1;
                Player1Turn();
            }
        }
    }

    /// <summary>
    /// setup the player 1 for its turn
    /// </summary>
    void Player1Turn()
    {
        // enabling player 1 slider form turn
        striker1Slider.interactable = true;

        // enabling player 1 striker and disabling player 2 striiker
        striker2.SetActive(false);
        striker1.SetActive(true);
    }

    /// <summary>
    /// setup player 2 for its turn
    /// </summary>
    void Player2Turn()
    {
        // disabling player 1 slider
        striker1Slider.interactable = false;

        // enabling player 2 striker and disabling player 1 striker
        striker2.SetActive(true);
        striker1.SetActive(false);
    }
}
