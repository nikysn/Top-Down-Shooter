using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
   /* [SerializeField] private List<GameObject> _prafabsCorpseBird;
    [SerializeField] private List<GameObject> _prefabsCorpseFatso;

    public GameObject GetCorpse(Enemy enemy)
    {

        if (enemy is Bird bird)
        {
           return ChooseRandom(_prafabsCorpseBird);
        }
        if (enemy is Fatso fatso)
        {
            return ChooseRandom(_prefabsCorpseFatso);
        }
        
        throw new InvalidOperationException("Забыли добавить тип");
    }

    private GameObject ChooseRandom(List<GameObject> corpses)
    {
        int index = Random.Range(0, corpses.Count);
        return corpses[index];
    }
   */
}
