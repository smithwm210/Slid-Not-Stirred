using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    private void Awake() {

        if (instance == null)
            instance = this;
        else{

            Destroy(gameObject);
            return;
        }


        foreach(Sounds s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }


    public void Play (string name){
        Sounds s = Array.Find(sounds,sound => sound.name == name);
        s.source.Play();
        Debug.Log("Sound Played");
    }
}
