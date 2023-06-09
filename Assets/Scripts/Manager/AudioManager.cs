using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Inspector variables
    [Header("References")]
    [Tooltip("Audio source responsible for playing the background music")]
    [SerializeField] AudioSource BGAudioSource;
    [Tooltip("Sound effects for striker hit")]
    [SerializeField] List<AudioSource> StrikerSFX;
    [Tooltip("Sound effects for pucks hit")]
    [SerializeField] List<AudioSource> PucksSFX;
    [Tooltip("Sound effects for piece hitting walls")]
    [SerializeField] List<AudioSource> WallSFX;
    [Tooltip("Sound effect for making a hole")]
    [SerializeField] AudioSource ScoreSFX;

    // Public variables
    public static AudioManager instance;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;

        // playing the Background music
        BGAudioSource.Play();
    }

    /// <summary>
    /// Plays a random striker hit sound effect
    /// </summary>
    public void StrikerHit()
    {
        PlaySFX(StrikerSFX);
    }

    /// <summary>
    /// Plays a random puck hit sound effect
    /// </summary>
    public void PuckHit()
    {
        PlaySFX(PucksSFX);
    }

    /// <summary>
    /// Plays a random wall hit sound effect
    /// </summary>
    public void WallHit()
    {
        PlaySFX(WallSFX);
    }

    /// <summary>
    /// Plays the sound effect when a piece goes into hole
    /// </summary>
    public void ScoreHit()
    {
        ScoreSFX.Play();
    }

    /// <summary>
    /// Plays a random track from list of audiosource
    /// </summary>
    /// <param name="list">list of audio source</param>
    void PlaySFX(List<AudioSource> list)
    {
        // getting a random index
        int index = Random.Range(0, list.Count);

        // playing the audio source at the index
        list[index].Play();
    }
}
