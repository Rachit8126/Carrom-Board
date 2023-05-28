using UnityEngine;
using UnityEngine.UI;

public class StrikerHorizontalMovementController : MonoBehaviour
{
    // Inspector Variables
    [Header("References")]
    [SerializeField] Slider StrikerControllerSlider;
    [SerializeField] Transform strikerTransform;

    [Header("Constants")]
    [Tooltip("The factor that controls how much the striker will move with respect to the slider")]
    [SerializeField] float moveFactor = 1.335f;

    #region Monobehaviour Functions
    private void Start()
    {
        StrikerControllerSlider.onValueChanged.AddListener(MoveSlider);
    }
    #endregion

    /// <summary>
    /// Used to Move the striker with respect to the slider value
    /// </summary>
    /// <param name="sliderValue"> the value of slider </param>
    public void MoveSlider(float sliderValue)
    {
        Vector2 currPosition = strikerTransform.position;
        currPosition.x = moveFactor * sliderValue;
        strikerTransform.position = currPosition;
    }
}
