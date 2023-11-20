using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Dirección predeterminada de la bala.
    public Vector2 direction = new Vector2(1, 0);

    // Velocidad de movimiento de la bala.
    public float speed = 2f;

    // Tiempo que la bala permanecerá viva antes de autodestruirse.
    public float timeAlive = 3f;

    // Daño que la bala inflige.
    public int damage = 10;

    // Indica si la bala es disparada por un enemigo.
    public bool isEnemy = false;

    // Temporizador interno para llevar la cuenta de cuánto tiempo ha estado viva la bala.
    private float timerLeft;

    private void Start()
    {
        // Inicializar el temporizador con el tiempo de vida establecido.
        timerLeft = timeAlive;
    }

    private void Update()
    {
        // Decrementar el temporizador cada frame.
        timerLeft -= Time.deltaTime;

        // Si el temporizador llega a cero, destruir la bala.
        if (timerLeft <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Mover la bala cada frame.
        MoveBullet();
    }

    // Método para manejar el movimiento de la bala.
    private void MoveBullet()
    {
        // Calcular la velocidad de la bala basada en su dirección y velocidad.
        Vector2 velocity = direction.normalized * speed;

        // Actualizar la posición de la bala.
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }

    // Método público para establecer la dirección de la bala desde otros scripts.
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
        // Orientar la bala en la dirección de movimiento.
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Método para establecer el daño de la bala.
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    // Lógica para detectar colisión con el cometa y destruir la bala.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))  // Asegúrate de que tu cometa tenga el tag "Obstacle".
        {
            Destroy(gameObject);
        }
    }
}