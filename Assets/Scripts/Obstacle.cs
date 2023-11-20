using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 10; // El da�o que el cometa inflige al jugador al atravesarlo.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player ship = other.GetComponent<Player>();
            if (ship != null)
            {
                ship.TakeDamage(damage);
            }
        }

        // Verifica la colisi�n con la DeathWall
        if (other.CompareTag("DeathWall"))
        {
            // Destruye el obst�culo sin aplicar da�o al jugador
            Destroy(gameObject);
        }
    }
}