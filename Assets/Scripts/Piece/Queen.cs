using UnityEngine;

public class Queen : Piece
{
    public override void InHole()
    {
        if(pieceRigidBody.velocity.magnitude <= 0.7f)
        {
            // Increase Score
            Debug.Log("Scored");

            // Notifying the turn manager that player has scored, so that we can give him second chance
            TurnManager.instance.scored = true;

            // Increasing the player's score
            GameManager.instance.IncreaseScore(2);

            // Disabling Gameobject
            this.gameObject.SetActive(false);
        }
    }
}
