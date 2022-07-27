using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDeathEffect : MonoBehaviour
{
    AudioSource audioSource;

    public List<AudioClip> audioclips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = audioclips[Random.Range(0, audioclips.Count)];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
