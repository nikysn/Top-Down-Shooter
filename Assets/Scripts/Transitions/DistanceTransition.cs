using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            {
                NeedTransit = true;
            }
        }
    }
}
