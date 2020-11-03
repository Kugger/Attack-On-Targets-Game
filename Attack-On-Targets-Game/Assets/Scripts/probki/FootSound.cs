
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class FootSound
{
    public string audioName;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public AudioSource audioSource;
}
