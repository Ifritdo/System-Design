using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Direcci�n predeterminada de la bala.
    public Vector2 direction = new Vector2(1, 0);

    // Velocidad de movimiento de la bala.
    public float speed = 2f;

    // Tiempo que la bala permanecer� viva antes de autodestruirse.
    public float timeAlive = 3f;

    // Da�o que la bala inflige.
    public int damage = 10;

    // Indica si la bala es disparada por un enemigo.
    public bool isEnemy = false;

    // Temporizador interno para llevar la cuenta de cu�nto tiempo ha estado viva la bala.
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

    // M�todo para manejar el movimiento de la bala.
    private void MoveBullet()
    {
        // Calcular la velocidad de la bala basada en su direcci�n y velocidad.
        Vector2 velocity = direction.normalized * speed;

        // Actualizar la posici�n de la bala.
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }

    // M�todo p�blico para establecer la direcci�n de la bala desde otros scripts.
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
        // Orientar la bala en la direcci�n de movimiento.
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // M�todo para establecer el da�o de la bala.
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    // L�gica para detectar colisi�n con el cometa y destruir la bala.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))  // Aseg�rate de que tu cometa tenga el tag "Obstacle".
        {
            Destroy(gameObject);
        }
    }
}