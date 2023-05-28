using System;
using UnityEngine;
using UnityEngine.UI;

public class ShootStriker : MonoBehaviour
{
    // Inspector Variables
    [Header("References")]
    [SerializeField] Rigidbody2D strikerRigidBody;
    [SerializeField] Slider strikerControllerSlider;
    [SerializeField] Transform strikerTransform;
    [SerializeField] GameObject helperArrow;

    [Header("Constants")]
    [Tooltip("The number that controls the magnitude of force applied to the striker")]
    [SerializeField] float forceScale;
    [SerializeField] float maxForce;

    // Public Variables
    public event Action OnStrikerShoot;
    [HideInInspector] public bool canShoot = true;

    // Private Variables
    /// <summary>
    /// the direction to shoot the striker
    /// </summary>
    Vector2 pullDirection;

    private void OnMouseDrag()
    {
        // check for mouse drag only when we can shoot
        if (canShoot)
        {
            // getting the direction of shooting the striker
            pullDirection = strikerTransform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // enabling helper arrow
            helperArrow.SetActive(true);

            // setting rotation of the helper arrow
            float angle = Mathf.Atan2(pullDirection.y, pullDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            helperArrow.transform.rotation = rotation;
        }
    }

    private void OnMouseUp()
    {
        // if we can shoot than shoot
        if (canShoot)
        {
            // disabling the helper arrow
            helperArrow.SetActive(false);

            // when mouse is released applying the force in the direction of shooting
            Vector2 force = Vector2.ClampMagnitude(pullDirection * forceScale, maxForce);
            strikerRigidBody.AddForce(force);

            // disabling slider to disbale controlled movement of striker
            strikerControllerSlider.interactable = false;

            // trigger the onStrikerShoot event
            OnStrikerShoot?.Invoke();

            // setting canShoot to false because you made a shot
            canShoot = false;

            // enabling the collider for striker
            this.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
