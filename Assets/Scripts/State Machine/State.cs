using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    protected Player Target { get; private set; }
    protected EnemyAnimation Animator { get; private set; }

    private void Start()
    {
        Animator = GetComponent<EnemyAnimation>();
    }
    public void Enter(Player target)
    {
        if(enabled == false)
        {
            Target = target;
            enabled = true;

            foreach(var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if(enabled)
        {
            foreach(var transition in _transitions)
            {
                transition.enabled = false;
                enabled = false;
            }
        }
    }

    public State GetNextState()
    {
        foreach(var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
