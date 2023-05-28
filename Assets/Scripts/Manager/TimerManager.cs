using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    // Inspector Variables
    [Header("References")]
    [SerializeField] TextMeshProUGUI timerText;

    [Header("Constants")]
    [SerializeField] float timerMaxTime;

    [SerializeField] UnityEvent onTimerOver;

    // Private Variables
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // updatig timer by subtractig deltaTime
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, timerMaxTime);

        // Updating Timer UI
        timerText.text = "Time: " + ((int)timer).ToString();

        // Checking if timer has run out
        if (timer <= 0)
        {
            // stopping the game when timer runs out
            Time.timeScale = 0f;

            // invoke the onTimerOver unity event
            onTimerOver?.Invoke();
        }
    }
}
