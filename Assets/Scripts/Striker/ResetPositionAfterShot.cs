using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResetPositionAfterShot : MonoBehaviour
{
    // Inspector Variables
    [Header("References")]
    [SerializeField] ShootStriker shootStriker;
    [SerializeField] Slider strikerControllerSlider;
    [SerializeField] Transform strikerTransform;
    [SerializeField] Rigidbody2D strikerRigidBody;
    [Tooltip("Assign this, only if this script is attached to AI")]
    [SerializeField] ShootAI shootAI;

    // Private Variables
    bool shouldReset = false;
    float initStrikerY;

    private void Start()
    {
        // subscribing SetShouldReset to OnStrikerShoot event
        if(shootStriker != null)
            shootStriker.OnStrikerShoot += ResetStriker;

        // storing the initial Y location of striker
        initStrikerY = strikerTransform.position.y;
    }

    /// <summary>
    /// Called to reset the position of striker
    /// </summary>
    /// <param name="minVelocity"> the value of minimum velocity for striker to reset </param>
    public void ResetStriker(float minVelocity)
    {
        // shouldReset should be set to true to reset striker after shot
        shouldReset = true;

        // start coroutine when event is invoked
        StartCoroutine(ResetStirkerCoroutine(minVelocity));
    }

    /// <summary>
    /// Called to reset the position of striker
    /// </summary>
    public void ResetStriker()
    {
        // shouldReset should be set to true to reset striker after shot
        shouldReset = true;

        // start coroutine when event is invoked
        StartCoroutine(ResetStirkerCoroutine(0));
    }

    IEnumerator ResetStirkerCoroutine(float minVelocity)
    {
        while(shouldReset)
        {
            // waiting for some time before checking for velocity
            yield return new WaitForSeconds(1f);

            // checking if striker velocity is close to 0
            if(strikerRigidBody.velocity.magnitude <= minVelocity)
            {

                // Reset Striker Position
                if (strikerControllerSlider != null)
                {
                    strikerControllerSlider.value = 0f;
                    strikerControllerSlider.interactable = true;
                }
                strikerTransform.position = new Vector2(0f, initStrikerY);

                if(shootStriker != null)
                    shootStriker.canShoot = true;

                shouldReset = false;

                // disabling the collision for striker
                this.GetComponent<Collider2D>().isTrigger = true;

                // Start next Turn
                TurnManager.instance.ChangeTurn();

                // Re-enabling shoot AI script to make the AI shoot again
                if (shootAI)
                {
                    shootAI.enabled = false;
                    shootAI.enabled = true;
                }
            }
        }
    }
}
