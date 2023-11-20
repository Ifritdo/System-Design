using UnityEngine;

public class EnemyRaycaster : MonoBehaviour
{
    public Transform player;  // Referencia al jugador.
    public LayerMask obstacleLayer;  // Capa de obst�culos.
    public float shootingRange = 10.0f;  // Rango en el que el enemigo puede detectar al jugador.
    public float raycastFrequency = 1.0f;  // Frecuencia con la que se env�an raycasts.
    public GameObject enemyBulletPrefab;  // Prefab de la bala del enemigo.
    public float bulletSpeed = 10.0f;  // Velocidad de la bala.

    private void Start()
    {
        // Si el jugador no est� asignado en el inspector, busca al jugador en la escena.
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
        // Calcula la direcci�n hacia el jugador.
        Vector2 directionToPlayer = player.position - transform.position;

        // Establece la direcci�n "frontal" del enemigo.
        Vector2 enemyForward = -transform.right; // Cambia 'transform.up' a 'transform.right'

        // Calcula el producto punto para determinar el �ngulo relativo.
        float dot = Vector2.Dot(enemyForward, directionToPlayer.normalized);

        // Debug para visualizar el valor del producto punto.
        Debug.Log("Dot value: " + dot);

        // Si dot es positivo, el jugador est� en frente del enemigo.
        if (dot > 0.5f) // Ajusta este valor bas�ndote en tus observaciones.
        {
            // Env�a un raycast en la direcci�n del jugador.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, shootingRange, obstacleLayer);

            // Si el raycast golpea al jugador y no hay obst�culos en medio, dispara.
            if (hit.collider != null && hit.collider.transform == player)
            {
                ShootAtPlayer(directionToPlayer.normalized);
            }
        }
    }

    private void ShootAtPlayer(Vector2 direction)
    {
        // Crea una bala y dispara en direcci�n al jugador.
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        // Aqu� llamamos al m�todo SetDirection para la bala
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}