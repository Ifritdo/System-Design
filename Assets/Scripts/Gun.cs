using UnityEngine;

public class Gun : MonoBehaviour
{
    // Prefab de la bala que se va a disparar.
    public GameObject bulletPrefab;

    // Dirección en la que se disparará la bala.
    public Vector2 bulletDirection = new Vector2(1, 0);  // Por defecto hacia la derecha.

    // Determina si el arma dispara automáticamente.
    public bool autoShoot = false;

    // Intervalo entre disparos y el posible retraso inicial antes de comenzar a disparar.
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;

    // Temporizadores internos para gestionar los disparos y el retraso.
    private float shootTimer = 0f;
    private float delayTimer = 0f;

    private AudioSource audioSource;

    public AudioClip shotSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        HandleShooting();
    }

    // Método que gestiona el comportamiento de disparo, incluyendo el retraso y el intervalo entre disparos.
    private void HandleShooting()
    {
        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;  // Restablece el temporizador de disparo después de disparar.
                }
                else
                {
                    shootTimer += Time.deltaTime;  // Incrementa el temporizador de disparo.
                }
            }
            else
            {
                delayTimer += Time.deltaTime;  // Incrementa el temporizador de retraso.
            }
        }
    }

    // Método para disparar una bala.
    public void Shoot()
    {
        // Determina la rotación de la bala basada en la dirección.
        Quaternion bulletRotation;
        if (bulletDirection.x > 0)
        {
            bulletRotation = Quaternion.Euler(0, 0, 0);  // Apunta hacia la derecha.
        }
        else
        {
            bulletRotation = Quaternion.Euler(0, 0, 180);  // Apunta hacia la izquierda.
        }

        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        // Usa la rotación calculada aquí.
        Bullet bulletComponent = bulletInstance.GetComponent<Bullet>();  // Aquí está la declaración.

        if (bulletComponent != null)
        {
            bulletComponent.SetDirection(bulletDirection);  // Establece la dirección de la bala.
        }

        if (audioSource != null && shotSound != null)
        {
            audioSource.PlayOneShot(shotSound);
        }
    }
}