using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [Header("Character rotation speed")]
    [SerializeField] private float _speedRotation;

    private void FixedUpdate()
    {
        Plane _playerPlane = new Plane(Vector3.up, transform.position);

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;

        if (_playerPlane.Raycast(_ray, out hitdist))
        {
            Vector3 targetPoint = _ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);
        }
    }
}
