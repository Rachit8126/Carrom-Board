using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Piece : MonoBehaviour
{
    // Inspector Variables
    [Header("Constants")]
    [SerializeField] protected int score;

    // Private variables
    protected Rigidbody2D pieceRigidBody;

    private void Start()
    {
        // getting the refernce of the rigidboy2d attacched to this piece
        pieceRigidBody = GetComponent<Rigidbody2D>();
    }

    public virtual void InHole()
    {
        return;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Checking if we collide with other pieces
    //    if (collision.gameObject.CompareTag("Piece"))
    //    {
    //        // Playing the sound effect for hitting other pieces
    //        AudioManager.instance.PuckHit();
    //    }

    //    // Checking if we collide with wall
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        // Playijng the sound effect for hitting walls
    //        AudioManager.instance.WallHit();
    //    }
    //}
}
