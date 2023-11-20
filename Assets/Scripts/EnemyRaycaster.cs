using UnityEngine;

public class EnemyRaycaster : MonoBehaviour
{
    public Transform player;  // Referencia al jugador.
    public LayerMask obstacleLayer;  // Capa de obstáculos.
    public float shootingRange = 10.0f;  // Rango en el que el enemigo puede detectar al jugador.
    public float raycastFrequency = 1.0f;  // Frecuencia con la que se envían raycasts.
    public GameObject enemyBulletPrefab;  // Prefab de la bala del enemigo.
    public float bulletSpeed = 10.0f;  // Velocidad de la bala.

    private void Start()
    {
        // Si el jugador no está asignado en el inspector, busca al jugador en la escena.
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        // Comienza a enviar raycasts regularmente.
        InvokeRepeating(nameof(CheckForPlayer), 0.0f, raycastFrequency);
    }
    private void CheckForPlayer()
    {
        // Calcula la dirección hacia el jugador.
        Vector2 directionToPlayer = player.position - transform.position;

        // Establece la dirección "frontal" del enemigo.
        Vector2 enemyForward = -transform.right; // Cambia 'transform.up' a 'transform.right'

        // Calcula el producto punto para determinar el ángulo relativo.
        float dot = Vector2.Dot(enemyForward, directionToPlayer.normalized);

        // Debug para visualizar el valor del producto punto.
        Debug.Log("Dot value: " + dot);

        // Si dot es positivo, el jugador está en frente del enemigo.
        if (dot > 0.5f) // Ajusta este valor basándote en tus observaciones.
        {
            // Envía un raycast en la dirección del jugador.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, shootingRange, obstacleLayer);

            // Si el raycast golpea al jugador y no hay obstáculos en medio, dispara.
            if (hit.collider != null && hit.collider.transform == player)
            {
                ShootAtPlayer(directionToPlayer.normalized);
            }
        }
    }

    private void ShootAtPlayer(Vector2 direction)
    {
        // Crea una bala y dispara en dirección al jugador.
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        // Aquí llamamos al método SetDirection para la bala
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}