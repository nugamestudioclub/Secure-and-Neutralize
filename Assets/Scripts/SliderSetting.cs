using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// https://johnleonardfrench.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/

public class SliderSetting : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVolume(float val)
    {
        if (mixer == null)
        {
            Debug.Log("Set the MIXER FIRST ");
            return;
        }

        mixer.SetFloat("MusicVol", Mathf.Log10(val) * 20f);
    }

    public void SetSensitivity(float val)
    {
        PlayerPrefs.SetFloat("Sensitivity", val);
    }
}
