using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private AudioClip soundheal;
    public int healAmount = 20; // La cantidad de salud que se restaurar�.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            

            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // Realiza cualquier l�gica relacionada con el jugador aqu�, por ejemplo, curaci�n.
                player.Heal(healAmount);
            }
            AudioManager.Instance.PlaySound(soundheal);
            Destroy(gameObject); // Destruimos el �tem despu�s de usarlo.
        }
    }
}
