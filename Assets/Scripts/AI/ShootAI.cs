using System.Collections;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    // Inspector Variables
    [Header("References")]
    [SerializeField] Rigidbody2D strikerRigidBody;
    [SerializeField] ResetPositionAfterShot resetStrikerController;

    [Header("Constants")]
    [SerializeField] float maxForceScale = 100;

    private void OnEnable()
    {
        // calling the shoot coroutine on AI chance
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        // waiting for some time before shooting
        yield return new WaitForSeconds(1f);

        // getting a random point
        Vector3 randomVector = Random.insideUnitSphere.normalized;

        // getting the direction of striker to random point
        Vector2 direction = randomVector - transform.position;

        // getting a random force scale to scale the power of shot randomly
        float forceScale = Random.Range(100, maxForceScale);

        // adding the sccaled force in the random direction we calculated
        strikerRigidBody.AddForce(direction * forceScale);

        // disabling components for next turn
        this.GetComponent<Collider2D>().isTrigger = false;

        // resetting the striker
        resetStrikerController.ResetStriker();
    }
}
