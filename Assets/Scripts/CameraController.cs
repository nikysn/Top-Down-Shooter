using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _dumping = 1.5f;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 1f);
    [SerializeField] private Transform _player;
    
    [SerializeField] float _leftLimit;
    [SerializeField] float _rightLimit;
    [SerializeField] float _bottomLimit;
    [SerializeField] float _upperLimit;
    
    private bool _isLeft;
    private int _lastX;

    private void Start()
    {
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        _lastX = Mathf.RoundToInt(_player.position.x);

        if (playerIsLeft)
        {
            transform.position = new Vector3(_player.position.x - _offset.x, _player.position.y - _offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
        }
    }

    private void Update()
    {
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);

            if(currentX > _lastX)
            {
                _isLeft = false;
            }
            else if (currentX < _lastX)
            {
                _isLeft=true;
            }

            _lastX = Mathf.RoundToInt(_player.position.x);

            Vector3 target;

            if (_isLeft)
            {
                target = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, transform.position.z);
            }

            else 
            {
                target = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
            transform.position = currentPosition;
        };

        transform.position = new Vector3
               (
               Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
               Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit),
               transform.position.z
               );
    }
}
