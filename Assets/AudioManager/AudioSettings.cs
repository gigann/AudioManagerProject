using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// For the Audio Settings sliders.
/// </summary>
public class AudioSettings : MonoBehaviour
{
    [SerializeField]  public Selectable masterVolumeSlider;
    [SerializeField] public Selectable soundVolumeSlider;
    [SerializeField]  public Selectable musicVolumeSlider;
    [SerializeField]  public Selectable ambienceVolumeSlider;

    /// <summary>
    /// Adjusts the Audio Manager singleton's master volume
    /// by the slider's value x 10.
    /// </summary>
    public void OnMasterVolumeChanged()
    {
        AudioManager.instance.AdjustMasterVolume(
            masterVolumeSlider.GetComponent<Slider>().value * 10);
    }

    /// <summary>
    /// Adjusts the Audio Manager singleton's master volume
    /// by the slider's value x 10.
    /// </summary>
    public void OnSoundVolumeChanged()
    {
        AudioManager.instance.AdjustSoundVolume(
            soundVolumeSlider.GetComponent<Slider>().value * 10);
    }

    /// <summary>
    /// Adjusts the Audio Manager singleton's master volume
    /// by the slider's value x 10.
    /// </summary>
    public void OnMusicVolumeChanged()
    {
        AudioManager.instance.AdjustMusicVolume(
            musicVolumeSlider.GetComponent<Slider>().value * 10);
    }

    /// <summary>
    /// Adjusts the Audio Manager singleton's master volume
    /// by the slider's value x 10.
    /// </summary>
    public void OnAmbienceVolumeChanged()
    {
        AudioManager.instance.AdjustAmbienceVolume(
            ambienceVolumeSlider.GetComponent<Slider>().value * 10);
    }
}
