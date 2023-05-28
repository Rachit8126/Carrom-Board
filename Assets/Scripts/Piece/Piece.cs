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
}
