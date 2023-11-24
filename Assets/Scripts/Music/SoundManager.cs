using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundHeal(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void PlaySoundExplosion(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}