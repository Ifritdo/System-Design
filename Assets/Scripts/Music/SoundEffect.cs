using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    // Update is called once per frame
    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(sound);
            Destroy(gameObject);
        }
    }
}
