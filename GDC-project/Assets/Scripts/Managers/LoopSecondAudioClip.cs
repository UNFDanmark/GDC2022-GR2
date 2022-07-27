using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSecondAudioClip : MonoBehaviour
{
    public AudioSource startingAudioSource;
    public AudioSource loopedAudioSource;
    
    void Start()
    {
        startingAudioSource.Play();
    }

    void Update()
    {
        if (!startingAudioSource.isPlaying && !loopedAudioSource.isPlaying)
        {
            loopedAudioSource.Play();
        }
    }
}
