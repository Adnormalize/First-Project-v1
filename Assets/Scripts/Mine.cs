using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject _minePrefab;
    [SerializeField] private int _maximumMumberOfMines = 1;

    private int _currentNumberOfMinutes = 0;
    private Vector3 _position;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (_maximumMumberOfMines > _currentNumberOfMinutes)
            {
                _currentNumberOfMinutes++;
                _position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);

                var _newMine = Instantiate(_minePrefab, _position, Quaternion.identity);
            }
        }
    }
}
