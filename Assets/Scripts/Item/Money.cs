using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : Item
{
    private float _money = 50f;
    public event UnityAction<float> ConveyMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ConveyMoney?.Invoke(_money);
            Disable();
        }
    }
}
