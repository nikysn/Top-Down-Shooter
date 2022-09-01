using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    private State _currentState;
    private Player _target; 

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if( _currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if( nextState != null)
        {
            Trinsit(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;
       
        if(_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Trinsit(State nextState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if(_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
