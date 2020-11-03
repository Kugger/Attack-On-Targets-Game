using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
//using System.Security.Policy;

public class AudioManagerFoots : MonoBehaviour
{
    public FootSound[] sounds;

    public static AudioManagerFoots instance;
    void Avake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(FootSound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        FootSound s = Array.Find(sounds, sound => sound.audioName == name);
        if (s == null)
            return;
        s.audioSource.Play(); 
    }
}
