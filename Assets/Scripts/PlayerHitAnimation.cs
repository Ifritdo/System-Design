using UnityEngine;

public class PlayerHitAnimation : MonoBehaviour
{
    [SerializeField] private float hitDuration = 1.0f;  // Duración de la animación de golpe en segundos

    private void Start()
    {
        DeactivateHitAnimation();
    }

    public void ActivateHitAnimation()
    {
        gameObject.SetActive(true);
        Invoke("DeactivateHitAnimation", hitDuration);
    }

    private void DeactivateHitAnimation()
    {
        gameObject.SetActive(false);
    }
}