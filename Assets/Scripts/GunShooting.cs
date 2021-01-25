using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce;

    private Vector3 _inputVector;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var _newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            var _newBulletBody = _newBullet.GetComponent<Rigidbody>();
            _newBulletBody.AddForce(transform.up * _bulletForce);
        }
    }
}
