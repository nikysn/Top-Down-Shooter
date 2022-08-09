using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    private WaitForSeconds _showTimeAwater = new WaitForSeconds(5);

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void ShowInPosition(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);   //
        StartCoroutine(RemoveFromSceneCoroutine());
    }

    public void SetDeathShowTime(float deathShowTime)
    {
        _showTimeAwater = new WaitForSeconds(deathShowTime);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator RemoveFromSceneCoroutine()
    {
        yield return _showTimeAwater;
        gameObject.SetActive(false);
        Disable();
    }
}
