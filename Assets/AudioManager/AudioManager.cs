using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

/// <summary>
/// Client-side singleton for managing and playing sound effects, background music, and ambience.
/// </summary>
public class AudioManager : MonoBehaviour
{
    // Singleton instance.
    public static AudioManager instance;

    // Audio mixer for the master channel.
    [SerializeField] private AudioMixer masterMixer;

    // Audio mixer for sound effects.
    [SerializeField] private AudioSource sourceSound;

    // Audio mixer for background music.
    [SerializeField] private AudioSource sourceMusic;

    // Audio mixer for ambience.
    [SerializeField] private AudioSource sourceAmbience;

    // Struct of audio clips associated with names.
    [System.Serializable]
    public struct Clip
    {
        public string name;
        public AudioClip file;
    }

    // Collection of sound effects exposed to the Unity Editor.
    public Clip[] SoundEffects;

    // Collection of music tracks exposed to the Unity Editor.
    public Clip[] MusicTracks;

    // Collection of ambience tracks exposed to the Unity Editor.
    public Clip[] AmbienceTracks;

    // Dictionary of sound effects.
    private Dictionary<string, AudioClip> SoundDict;

    // Dictionary of music tracks.
    private Dictionary<string, AudioClip> MusicDict;

    // Dictionary of ambience tracks.
    private Dictionary<string, AudioClip> AmbienceDict;

    /// <summary>
    /// Singleton initialization.
    /// </summary>
    private void Awake()
    {
        // If an Audio Manager instance already exists, destroy the new one.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Instantiate the Audio Manager instance and keep it alive between scene changes.
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            // Instantiate dicts.
            SoundDict = new Dictionary<string, AudioClip>();
            MusicDict = new Dictionary<string, AudioClip>();
            AmbienceDict = new Dictionary<string, AudioClip>();

            // Add Clip values from the Unity Editor.
            foreach (Clip clip in SoundEffects)
            {
                SoundDict.Add(clip.name, clip.file);
            }
            foreach (Clip clip in MusicTracks)
            {
                MusicDict.Add(clip.name, clip.file);
            }
            foreach (Clip clip in AmbienceTracks)
            {
                AmbienceDict.Add(clip.name, clip.file);
            }
        }
    }

    // Playing Files

    /// <summary>
    /// Plays a random sound effect.
    /// </summary>
    /// <param name="soundNames">possible sound effects to play</param>
    public void PlaySound(params string[] soundEffectNames)
    {
        // Select a random sound effect.
        string randomClip = soundEffectNames.ElementAt(Random.Range(0, soundEffectNames.Length));

        // Play it.
        sourceSound.PlayOneShot((AudioClip)SoundDict[randomClip], sourceSound.volume);
    }

    /// <summary>
    /// Plays a random music track.
    /// </summary>
    /// <param name="loop">set to false to disable looping</param>
    /// <param name="songNames">possible music tracks to play</param>
    public void PlaySong(bool loop, params string[] songTracks)
    {
        // Select a random music track.
        string randomClip = songTracks.ElementAt(Random.Range(0, songTracks.Length));

        // Play it.
        sourceMusic.clip = (AudioClip)MusicDict[randomClip];
        sourceMusic.loop = loop;
        sourceMusic.Play();
    }

    /// <summary>
    /// Plays random ambience.
    /// </summary>
    /// <param name="loop">set to false to disable looping</param>
    /// <param name="songNames">possible ambience to play</param>
    public void PlayAmbience(bool loop, params string[] ambienceTracks)
    {
        // Select a random ambience track.
        string randomClip = ambienceTracks.ElementAt(Random.Range(0, ambienceTracks.Length));

        // Play it.
        sourceAmbience.clip = (AudioClip)AmbienceDict[randomClip];
        sourceAmbience.loop = loop;
        sourceAmbience.Play();
    }


    // Volume Adjustment

    /// <summary>
    /// Adjusts the volume of the Master AudioMixer.
    /// </summary>
    /// <param name="newVolume">The new volume of the Master AudioMixer.</param>
    public void AdjustMasterVolume(float newVolume)
    {
        masterMixer.SetFloat("masterVolume", newVolume);
    }

    /// <summary>
    /// Adjusts the volume of the Sound Effect AudioMixer.
    /// </summary>
    /// <param name="newVolume">The new volume of the Sound Effect AudioMixer.</param>
    public void AdjustSoundVolume(float newVolume)
    {
        masterMixer.SetFloat("soundVolume", newVolume);
    }

    /// <summary>
    /// Adjusts the volume of the Background Music AudioMixer.
    /// </summary>
    /// <param name="newVolume">The new volume of the Background Music AudioMixer.</param>
    public void AdjustMusicVolume(float newVolume)
    {
        masterMixer.SetFloat("musicVolume", newVolume);
    }

    /// <summary>
    /// Adjusts the volume of the Ambience AudioMixer.
    /// </summary>
    /// <param name="newVolume">The new volume of the Ambience AudioMixer.</param>
    public void AdjustAmbienceVolume(float newVolume)
    {
        masterMixer.SetFloat("ambienceVolume", newVolume);
    }
}