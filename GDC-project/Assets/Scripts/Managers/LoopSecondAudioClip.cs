using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSecondAudioClip : MonoBehaviour
{
    public AudioClip startingAudioClip;
    public AudioClip loopedAudioClip;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        audioSource.clip = startingAudioClip;
        audioSource.Play();
    }

    void Update()
    {
        if(audioSource.clip == startingAudioClip && !audioSource.isPlaying)
        {
            audioSource.clip = loopedAudioClip;
            audioSource.loop = true;
        }
    }
}
