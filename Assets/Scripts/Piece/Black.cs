using UnityEngine;

public class Black : Piece
{
    public override void InHole()
    {
        if(pieceRigidBody.velocity.magnitude <= 2f)
        {
            // Increase Score
            Debug.Log("Scored");

            // Notifying the turn manager that player has scored, so that we can give him second chance
            TurnManager.instance.scored = true;

            // Increasing the player's score
            GameManager.instance.IncreaseScore(1);

            // Disabling Gameobject
            this.gameObject.SetActive(false);

            // Playing the Sound effect
            AudioManager.instance.ScoreHit();
        }
    }
}
