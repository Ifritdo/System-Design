using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingMissileFail : MonoBehaviour
{
    [SerializeField] private float _missileSpeed = 6f;
    [SerializeField] private float _rotateSpeed = 1000f;
    private GameObject _player;
    private Vector3 _playerPos;

    void Start()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
        {
            Debug.Log("Player is null");
        }
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        if (transform.name == "Boss_Homing_Left_Missile" || transform.name == "Boss_Homing_Right_Missile")
        {
            BossHomingMissileMovement();
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void BossHomingMissileMovement()
    {
        if (_player != null)
        {
            _playerPos = _player.transform.position;

            transform.Translate((_playerPos - transform.position).normalized * _missileSpeed * Time.deltaTime);

            Quaternion _rotateTarget = Quaternion.LookRotation(transform.forward, -(_playerPos - transform.position).normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotateTarget, _rotateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("Laser") || other.CompareTag("Explosion") || other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
