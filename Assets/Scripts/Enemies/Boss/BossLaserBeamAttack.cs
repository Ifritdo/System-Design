using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBeamAttack : MonoBehaviour
{
    private float _bossSpeed = 4;
    [SerializeField] private GameObject _laserBeam;
    private bool _isLaserBeamReady = false;
    private bool _hasUsedLaserBeam = false;

    void Start()
    {
        if (_laserBeam == null)
        {
            Debug.Log("_laserBeam is NULL");
        }

        if (transform.position.x > 0)
        {
            transform.Rotate(0, 0, 270);
        }
        else if (transform.position.x < 0)
        {
            transform.Rotate(0, 0, 90);
        }
    }

    void Update()
    {
        BossMovement();
        FireLaserBeam();
    }

    private void BossMovement()
    {
        transform.Translate(Vector3.up * _bossSpeed * Time.deltaTime);

        if (transform.position.y < -9)
        {
            Destroy(gameObject);
        }
    }

    private void FireLaserBeam()
    {
        if (transform.position.y <= 1)
        {
            _isLaserBeamReady = true;
        }

        if (_isLaserBeamReady && !_hasUsedLaserBeam)
        {
            StartCoroutine(LaserBeamAttack());
        }
    }

    IEnumerator LaserBeamAttack()
    {
        _hasUsedLaserBeam = true;
        _laserBeam.SetActive(true);
        yield return null;
    }
}
