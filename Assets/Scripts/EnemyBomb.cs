using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private int damage = 10; // Daño que el enemigo causa al chocar con el jugador.
    [SerializeField] private int pointsValue = 0;

    private float topBound;
    private float bottomBound;

    [Header("Enemy Movement")]
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    public float bombSpeed = 2f;
    public GameObject explosionPrefab;

    [System.Serializable]
    public struct DropItem
    {
        public GameObject itemPrefab;
        public float dropProbability;
    }
    [Header("Drop Items")]
    public DropItem[] dropItems;

    private Transform playerTransform;

    public GameObject explosionProjectile; // Proyectil de la explosión
    public int numberOfProjectiles = 8;    // Número de proyectiles
    public float explosionForce = 5f;      // Fuerza de la explosión

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        SetBounds();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void SetBounds()
    {
        if (mainCamera == null) return;

        float camHalfHeight = mainCamera.orthographicSize;
        float spriteHalfHeight = spriteRenderer.bounds.extents.y;

        topBound = mainCamera.transform.position.y + camHalfHeight - spriteHalfHeight;
        bottomBound = mainCamera.transform.position.y - camHalfHeight + spriteHalfHeight;
    }

    private void Update()
    {
        ClampPosition();

        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)direction * bombSpeed * Time.deltaTime;
        }
    }

    private void ClampPosition()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, bottomBound, topBound);
        transform.position = position;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player ship = collision.gameObject.GetComponent<Player>();
            if (ship != null)
            {
                ship.TakeDamage(damage);
                Explode();
            }
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            Explode();
            Destroy(collision.gameObject);
        }
    }

    public void Explode()
    {
        // Mostrar la animación de explosión
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Disparar proyectiles en diferentes direcciones
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = angleStep * i;
            Vector2 projectileDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            var proj = Instantiate(explosionProjectile, transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().AddForce(projectileDirection * explosionForce, ForceMode2D.Impulse);

            // Esta es la parte donde obtenemos el daño directamente del prefab de la bala.
            var bulletScript = explosionProjectile.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                var bulletOnScene = proj.GetComponent<Bullet>();
                bulletOnScene.damage = bulletScript.damage;
                Debug.Log("Daño asignado a la bala: " + bulletOnScene.damage);
            }
        }

        TryDropItem();
        Destroy(gameObject);
    }


    public void TryDropItem()
    {
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.value <= dropItem.dropProbability)
            {
                Instantiate(dropItem.itemPrefab, transform.position, Quaternion.identity);
                Debug.Log($"El enemigo {gameObject.name} ha soltado un ítem: {dropItem.itemPrefab.name} en la posición: {transform.position}");
                break;
            }
        }
    }

    public int GetPointsValue()
    {
        return pointsValue;
    }
}
