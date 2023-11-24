using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private AudioClip soundheal;
    public int healAmount = 20; // La cantidad de salud que se restaurará.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            

            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // Realiza cualquier lógica relacionada con el jugador aquí, por ejemplo, curación.
                player.Heal(healAmount);
            }
            AudioManager.Instance.PlaySound(soundheal);
            Destroy(gameObject); // Destruimos el ítem después de usarlo.
        }
    }
}
