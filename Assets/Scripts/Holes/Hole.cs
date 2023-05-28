using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // getting the reference of Piece if available
        Piece piece = collision.GetComponent<Piece>();

        // check if we get a valid Piece Reference => A piece is overlapping with the trigger
        if (piece != null)
        {
            // calling the in hole function for the puck that got into this hole
            piece.InHole();
        }
    }
}
