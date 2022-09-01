using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private WaitForSeconds _showTimeAwater;
    private int _timeLife = 15;

    private void Start()
    {
        _showTimeAwater = new WaitForSeconds(_timeLife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Disable();
        }
    }

    public void SetDeathShowTime(float deathShowTime)
    {
        _showTimeAwater = new WaitForSeconds(deathShowTime);
    }

    public void ShowInPosition(Vector3 position)
    {
        int maxNumber = 5;
        int numberRundom = Random.Range(0, maxNumber);

        if (numberRundom == 0)
        {
            transform.position = position;
            Enable();
            StartCoroutine(RemoveFromSceneCoroutine());
        }
    }

    public IEnumerator RemoveFromSceneCoroutine()
    {
        yield return _showTimeAwater;

        if (gameObject.activeSelf)
        {
            Disable();
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
