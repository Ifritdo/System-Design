using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int damage = 10;  // Da�o que inflige el enemigo al jugador
    [SerializeField] private int pointsValue = 0;  // Puntos que otorga al ser destruido

    [Header("Enemy Movement")]
    [SerializeField] private SpriteRenderer spriteRenderer;  // Renderer del sprite para obtener dimensiones
    private Camera mainCamera;  // C�mara principal para establecer l�mites

    [System.Serializable]
    public struct DropItem
    {
        public GameObject itemPrefab;
        public float dropProbability;
    }

    [Header("Drop Items")]
    public DropItem[] dropItems;  // Lista de �tems que el enemigo puede soltar

    [Header("Audio")]
    [SerializeField] private SoundManager soundManager;  // Referencia al SoundManager

    private float topBound;  // L�mite superior de movimiento
    private float bottomBound;  // L�mite inferior de movimiento

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
        // Establece los l�mites de movimiento basados en la c�mara y el tama�o del sprite
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
        // Mantiene al enemigo dentro de los l�mites establecidos
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, bottomBound, topBound);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica la colisi�n con el jugador y aplica da�o
        if (collision.gameObject.CompareTag("Player"))
        {
            Player ship = collision.gameObject.GetComponent<Player>();
            if (ship != null)
            {
                ship.TakeDamage(damage);
            }
        }
        // Verifica la colisi�n con un proyectil del jugador
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TryDropItem();
        }

        // Verifica la colisi�n con la DeathWall
        if (collision.gameObject.CompareTag("DeathWall"))
        {
            // Destruye el enemigo sin sumar puntos al score ni reproducir sonido
            Destroy(gameObject);
        }
    }

    public void TryDropItem()
    {
        Debug.Log($"Intentando soltar �tem para el enemigo {gameObject.name}");

        // Intenta soltar un �tem basado en la probabilidad establecida
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.value <= dropItem.dropProbability)
            {
                Instantiate(dropItem.itemPrefab, transform.position, Quaternion.identity);
                Debug.Log($"El enemigo {gameObject.name} ha soltado un �tem: {dropItem.itemPrefab.name} en la posici�n: {transform.position}");

                // Reproduce el sonido de explosi�n siempre que se suelte un �tem
                if (soundManager != null)
                {
                    soundManager.PlayExplosionSound(true);
                }

                break;
            }
            else
            {
                Debug.Log($"El enemigo {gameObject.name} no ha soltado un �tem en esta ocasi�n.");
            }
        }
    }

    // M�todo para manejar el impacto de la bala en el enemigo
    public void HandleBulletHit()
    {
        // L�gica para manejar el impacto de la bala en el enemigo
        // Puedes agregar m�s l�gica aqu� seg�n sea necesario
    }

    // M�todo para obtener el valor en puntos del enemigo
    public int GetPointsValue()
    {
        return pointsValue;
    }

    // M�todo para obtener el da�o del enemigo
    public int GetDamage()
    {
        return damage;
    }
}