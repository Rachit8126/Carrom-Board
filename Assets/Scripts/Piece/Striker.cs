using UnityEngine;

[RequireComponent(typeof(ResetPositionAfterShot))]
public class Striker : Piece
{
    // Private Variables
    ResetPositionAfterShot resetPositionAfterShot;

    private void Start()
    {
        resetPositionAfterShot = GetComponent<ResetPositionAfterShot>();
    }

    public override void InHole()
    {
        // if the striker goes in to hole, reset it.
        resetPositionAfterShot.ResetStriker(0.5f);

        if(this.GetComponent<Rigidbody>().velocity.magnitude <= 1.5f)
        {
            // Playing the Sound effect
            AudioManager.instance.ScoreHit();
        }
    }
}
