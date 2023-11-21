using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int damage = 10;  // Daño que inflige el enemigo al jugador
    [SerializeField] private int pointsValue = 0;  // Puntos que otorga al ser destruido

    [Header("Enemy Movement")]
    [SerializeField] private SpriteRenderer spriteRenderer;  // Renderer del sprite para obtener dimensiones
    private Camera mainCamera;  // Cámara principal para establecer límites

    [System.Serializable]
    public struct DropItem
    {
        public GameObject itemPrefab;
        public float dropProbability;
    }

    [Header("Drop Items")]
    public DropItem[] dropItems;  // Lista de ítems que el enemigo puede soltar

    [Header("Audio")]
    [SerializeField] private SoundManager soundManager;  // Referencia al SoundManager

    private float topBound;  // Límite superior de movimiento
    private float bottomBound;  // Límite inferior de movimiento

    private void Awake()
    {
        // Inicializaciones
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        mainCamera = Camera.main;
        SetBounds();
    }

    private void SetBounds()
    {
        // Establece los límites de movimiento basados en la cámara y el tamaño del sprite
        if (mainCamera == null) return;

        float camHalfHeight = mainCamera.orthographicSize;
        float spriteHalfHeight = spriteRenderer.bounds.extents.y;

        topBound = mainCamera.transform.position.y + camHalfHeight - spriteHalfHeight;
        bottomBound = mainCamera.transform.position.y - camHalfHeight + spriteHalfHeight;
    }

    private void LateUpdate()
    {
        ClampPosition();
    }

    private void ClampPosition()
    {
        // Mantiene al enemigo dentro de los límites establecidos
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, bottomBound, topBound);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica la colisión con el jugador y aplica daño
        if (collision.gameObject.CompareTag("Player"))
        {
            Player ship = collision.gameObject.GetComponent<Player>();
            if (ship != null)
            {
                ship.TakeDamage(damage);
            }
        }
        // Verifica la colisión con un proyectil del jugador
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TryDropItem();
        }

        // Verifica la colisión con la DeathWall
        if (collision.gameObject.CompareTag("DeathWall"))
        {
            // Destruye el enemigo sin sumar puntos al score ni reproducir sonido
            Destroy(gameObject);
        }
    }

    public void TryDropItem()
    {
        Debug.Log($"Intentando soltar ítem para el enemigo {gameObject.name}");

        // Intenta soltar un ítem basado en la probabilidad establecida
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.value <= dropItem.dropProbability)
            {
                Instantiate(dropItem.itemPrefab, transform.position, Quaternion.identity);
                Debug.Log($"El enemigo {gameObject.name} ha soltado un ítem: {dropItem.itemPrefab.name} en la posición: {transform.position}");

                // Reproduce el sonido de explosión siempre que se suelte un ítem
                if (soundManager != null)
                {
                    soundManager.PlayExplosionSound(true);
                }

                break;
            }
            else
            {
                Debug.Log($"El enemigo {gameObject.name} no ha soltado un ítem en esta ocasión.");
            }
        }
    }

    // Método para manejar el impacto de la bala en el enemigo
    public void HandleBulletHit()
    {
        // Lógica para manejar el impacto de la bala en el enemigo
        // Puedes agregar más lógica aquí según sea necesario
    }

    // Método para obtener el valor en puntos del enemigo
    public int GetPointsValue()
    {
        return pointsValue;
    }

    // Método para obtener el daño del enemigo
    public int GetDamage()
    {
        return damage;
    }
}