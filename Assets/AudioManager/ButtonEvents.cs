using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For demoing the Audio Manager.
/// </summary>
public class ButtonEvents : MonoBehaviour
{
    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    public void PlaySound()
    {
        AudioManager.instance.PlaySound("test sound 1", 
            "test sound 2", "test sound 3");
    }

    /// <summary>
    /// Randomizes music.
    /// </summary>
    public void ShuffleMusic()
    {
        AudioManager.instance.PlaySong(true, "test music 1",
            "test music 2", "test music 3");
    }

    /// <summary>
    /// Randomizes ambience.
    /// </summary>
    public void ShuffleAmbience()
    {
        AudioManager.instance.PlayAmbience(true, "test ambience 1",
            "test ambience 2", "test ambience 3");
    }
}
