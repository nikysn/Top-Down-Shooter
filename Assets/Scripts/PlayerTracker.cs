using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] Player _player;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y,transform.position.z);
    }
}
