using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _camera;
    [SerializeField] private Shooting _shooting;

    private Rigidbody2D _rigidbody;
    private Vector2 _currentPosition;
    private Vector2 _mousePosition;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _shooting.ChangeSpeed += ChangeSpeed;
    }

    private void OnDisable()
    {
        _shooting.ChangeSpeed -= ChangeSpeed;
    }
    private void Update()
    {
        _currentPosition.x = Input.GetAxisRaw(Horizontal);
        _currentPosition.y = Input.GetAxisRaw(Vertical);

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _currentPosition * _moveSpeed * Time.deltaTime);
        Vector2 lookPlayer = _mousePosition - _rigidbody.position;
        float angle = Mathf.Atan2(lookPlayer.y, lookPlayer.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }

    public void ChangeSpeed(float speed)
    {
        _moveSpeed = speed;
    }
}
