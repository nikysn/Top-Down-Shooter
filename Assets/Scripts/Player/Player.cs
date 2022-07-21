using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Player _player;
    
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector2 _rotate;


    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Move.performed += ctx => OnMove();
        _input.Player.Look.performed += ctx => OnLook();
    }

    private void Update()
    {
        Debug.Log(_rotate.x + " " + _rotate.y);
        OnMove();
        Move(_direction);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnLook()
    {
        _rotate = _input.Player.Look.ReadValue<Vector2>();
    }

    private void OnMove()
    {
        _direction = _input.Player.Move.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        float speed = _moveSpeed * Time.deltaTime;
        

        Vector3 move = direction;

        transform.position += speed * move;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;

        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;

    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
