using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Modifica el método para aceptar un parámetro 'shouldPlay'
    public void PlayExplosionSound(bool shouldPlay)
    {
        Debug.Log($"Intentando reproducir sonido. shouldPlay: {shouldPlay}, AudioSource: {audioSource}");

        if (shouldPlay && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}