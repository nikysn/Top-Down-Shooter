using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Camera _camera;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    private Rigidbody2D _rigidbody;
    private Vector2 _currentPosition;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _currentPosition.x = Input.GetAxisRaw(_horizontal);
        _currentPosition.y = Input.GetAxisRaw(_vertical);

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _currentPosition * _moveSpeed * Time.deltaTime);

        Vector2 lookPlayer = _mousePosition - _rigidbody.position;
        float angle = Mathf.Atan2(lookPlayer.y, lookPlayer.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }
}
