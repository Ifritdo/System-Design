using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public HealthBar healthBar;
    public SoundManager soundManager;
    Gun[] guns;

    public float invulnerabilityDuration = 5f;
    private bool isInvulnerable = false;
    private float timeSinceDamage;
    float moveSpeed = 5;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;
    bool shoot;

    private Animator fireAnimator;  // Referencia al componente Animator del objeto hijo.
    private PlayerHitAnimation hitAnimation;  // Referencia al nuevo script de animaci�n de golpe.

    void Start()
    {
        healthBar.SetHealth(health);
        guns = transform.GetComponentsInChildren<Gun>();

        // Ajusta el nombre del objeto hijo que representa el fuego.
        Transform fireObject = transform.Find("FireAnimation");

        // Verificamos si el objeto FireAnimation existe antes de intentar obtener el Animator.
        if (fireObject != null)
        {
            fireAnimator = fireObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("No se encontr� el objeto FireAnimation.");
        }

        hitAnimation = transform.Find("GetHit").GetComponent<PlayerHitAnimation>();
        hitAnimation.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isInvulnerable)
        {
            timeSinceDamage += Time.deltaTime;
            if (timeSinceDamage >= invulnerabilityDuration)
            {
                isInvulnerable = false;
                Debug.Log("La nave ya no es invulnerable");
            }
        }

        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        shoot = Input.GetKeyDown(KeyCode.Mouse0);

        if (shoot)
        {
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }

        if (fireAnimator != null)
        {
            fireAnimator.SetBool("IsMoving", moveUp || moveDown || moveLeft || moveRight);

            if (!(moveUp || moveDown || moveLeft || moveRight))
            {
                fireAnimator.SetBool("IsIdle", true);  // Si no se est� moviendo, activa la animaci�n de fuego.
            }
            else
            {
                fireAnimator.SetBool("IsIdle", false);  // Si se est� moviendo, desactiva la animaci�n de fuego.
            }
        }

        // Actualizamos el Animator bas�ndonos en si el jugador est� presionando Shift.
        fireAnimator.SetBool("IsMovingFast", speedUp);
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime;

        if (speedUp)
        {
            moveAmount *= 3;
        }

        Vector2 move = Vector2.zero;
        if (moveUp) move.y += moveAmount;
        if (moveDown) move.y -= moveAmount;
        if (moveLeft) move.x -= moveAmount;
        if (moveRight) move.x += moveAmount;

        float moveMagnitude = move.magnitude;
        if (moveMagnitude > moveAmount)
        {
            move = move.normalized * moveAmount;
        }

        pos += move;

        float shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float shipHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + shipWidth / 2;
        float rightLimitAdjustment = 5.0f;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x - shipWidth / 2 - rightLimitAdjustment;

        float minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + shipHeight / 2;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y - shipHeight / 2;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"La nave ha colisionado con: {collision.gameObject.name} con el tag {collision.gameObject.tag}");

        // Ignoramos las balas del jugador
        if (collision.CompareTag("PlayerBullet"))
        {
            return;
        }

        if (collision.CompareTag("HealItem"))
        {
            Heal(10);
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("EnemyBullet"))
        {
            BulletBoss bossBullet = collision.gameObject.GetComponent<BulletBoss>();
            EnemyBullet enemyBullet = collision.gameObject.GetComponent<EnemyBullet>();
            if (bossBullet != null || enemyBullet != null)
            {
                TakeDamage(enemyBullet.damage);
                TakeDamage(bossBullet.damageToPlayer);
                return;
            }
        }

        //if (collision.CompareTag("EnemyShip"))
        //{
        //    Enemy enemyShip = collision.gameObject.GetComponent<Enemy>();
        //    if (enemyShip != null)
        //    {
        //        print("hola!");
        //        TakeDamage(enemyShip.damage);
        //        return;
        //    }
        //}

        else if (!isInvulnerable)
        {

            // Si no se pudo determinar el tipo o obtener el componente, registras una advertencia.
            Debug.LogWarning($"Da�o no reconocido al chocar con: {collision.gameObject.name} con el tag {collision.gameObject.tag}");
        }
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("Da�o recibido: " + damage);
        Debug.Log($"Intento de infligir da�o. Estado de invulnerabilidad: {isInvulnerable}");

        if (isInvulnerable)
            return;

        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            // Desactivar enemigos y balas
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyShip"))
            {
                enemy.SetActive(false);
            }
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("EnemyBullet"))
            {
                bullet.SetActive(false);
            }

            // Aqu� puedes agregar cualquier l�gica adicional antes de cargar la escena

            // Cargar la escena "EndSceneD"
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndSceneD");
        }

        // Reproducir la animaci�n de golpe (activarla)
        hitAnimation.ActivateHitAnimation();

        isInvulnerable = true;
        timeSinceDamage = 0;
    }

    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
        healthBar.SetHealth(health);
    }
}
