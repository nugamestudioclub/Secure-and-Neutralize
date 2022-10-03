using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    // Fill this with all the audio assets IN EDITOR
    [SerializeField]
    List<AudioClip> clips;

    Dictionary<string, AudioClip> dict;

    public static AudioManagerScript instance;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);

        instance = this;
    }

    private void Start()
    {
        dict = new Dictionary<string, AudioClip>();

        foreach (AudioClip c in clips)
        {
            dict.Add(c.name, c);
        }
    }

    public void PlaySound(AudioSource s, string filename)
    {
        // set the soundclip of s to filename (from dictionary)

        // play sound of s
        if (s.clip.name != filename)
        {
            s.clip = dict[filename];
        }

        s.Play();
    }


}
