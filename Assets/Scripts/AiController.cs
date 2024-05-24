using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum IAState
{
    None,
    Idle,
    Walk,
    Looking,
    PlayerSeen,
    PlayerNear,
}

public class AiController : MonoBehaviour
{
    private IAState _state = IAState.None;
    public bool PlayerNear = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _waypoint;

    private void Update()
    {
        CheckTransition();
        Behaviour();
    }

    private void Behaviour()
    {
        _agent = GetComponent<NavMeshAgent>();

        switch (_state)
        {
            case IAState.None:
                //
                //
                break;
            case IAState.Idle:
                //
                //
                break;
            case IAState.Walk:

                Walk();

                break;
            case IAState.Looking:
                //
                //
                break;
            case IAState.PlayerSeen:
                //
                //
                break;
            case IAState.PlayerNear:
                //
                //
                break;
        }
    }

    
    IEnumerator WaypointRoute()
    {
        Walk();
        yield return new WaitForSeconds(3);
    }


    private void Walk()
    {
        int index = 0;

        StartCoroutine(WaypointRoute());

        _agent.SetDestination(_waypoint[index].transform.position);
    }

    private void CheckTransition()
    {
        switch (_state)
        {
            case IAState.None:
                break;

            case IAState.Idle:

                if (PlayerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }

                break;

            case IAState.Walk:

                if (PlayerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }

                break;

            case IAState.Looking:

                if (PlayerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }

                break;

            case IAState.PlayerSeen:

                if (PlayerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }

                break;

            case IAState.PlayerNear:

                if (!PlayerNear)        // --- PLUS NEAR ---
                {
                    _state = IAState.Walk;
                }

                break;
        }
    }
}
