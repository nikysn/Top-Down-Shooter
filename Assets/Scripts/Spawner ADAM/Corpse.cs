using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    private WaitForSeconds _showTimeAwater;

    public void ShowInPosition(Vector3 position)
    {
        transform.position = position;
        Enable();
        StartCoroutine(RemoveFromSceneCoroutine());
    }

    public void SetDeathShowTime(float deathShowTime)
    {
        _showTimeAwater = new WaitForSeconds(deathShowTime);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator RemoveFromSceneCoroutine()
    {
        yield return _showTimeAwater;
        Disable();
    }
}
