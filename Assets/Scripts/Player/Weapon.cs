using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private GunSettings _gunSettings;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Shooting>(out Shooting shooting))
        {
            shooting.SetGunSettings(_gunSettings);
            gameObject.SetActive(false);
        }
    }
}
