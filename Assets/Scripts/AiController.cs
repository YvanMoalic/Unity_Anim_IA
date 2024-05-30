using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;


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
    private IAState _state = IAState.Walk;
    public bool _playerNear = false;
    public bool _playerSeen = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _waypoint;
    [SerializeField] private int WaypointIndex = 0;
    [SerializeField] private bool walkTrigger = false;
    public GameObject _player;


    private void Start()
    {
        StartCoroutine(CalculateSpeed());
    }

    private void Update()
    {
        CheckTransition();
        Behaviour();        
    }


    IEnumerator CalculateSpeed()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            Vector3 lastPosition = transform.position;
            yield return new WaitForFixedUpdate();
            _animator.SetFloat("Speed", Mathf.RoundToInt(Vector3.Distance(transform.position, lastPosition) / Time.fixedDeltaTime));
        }
        
    
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

                StartCoroutine(WaypointRoute());

                break;
            case IAState.Looking:
                //
                //
                break;
            case IAState.PlayerSeen:

                _playerSeen = true;
                PlayerSeen();
                
                break;
            case IAState.PlayerNear:
                //
                //
                break;
        }
    }

    
    IEnumerator WaypointRoute()
    {

        if (!walkTrigger)
        {
            walkTrigger = true;
            while (_state == IAState.Walk)
            {
                Walk();
                yield return new WaitForSeconds(8);
            }
        }              
    }

    private void Walk()
    {        

        if(WaypointIndex == 0)
        {
            _agent.SetDestination(_waypoint[WaypointIndex].transform.position);
            WaypointIndex = 1;
        }
        else
        {
            _agent.SetDestination(_waypoint[WaypointIndex].transform.position);
            WaypointIndex = 0;
        }

    }


    private void PlayerSeen()
    {
        _agent.SetDestination(_player.transform.position);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSeen = true;
        }
    }

    private void CheckTransition()
    {
        switch (_state)
        {
            case IAState.None:
                break;

            case IAState.Idle: //IDLE

                if (_playerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }
                else if (_playerSeen)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Seen", true);
                }

                break;

            case IAState.Walk: //WALK

                
                if (_playerSeen)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("Seen", true);
                }

                break;

            case IAState.Looking: //LOOKING

                if (_playerNear)        // --- NEAR ---
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Near", true);
                }
                else if (_playerSeen)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Seen", true);
                }

                break;

            case IAState.PlayerSeen: //SEEN
                _animator.SetBool("Seen", true);
                break;

            case IAState.PlayerNear: //NEAR

                if (!_playerNear)        // --- PLUS NEAR ---
                {
                    _state = IAState.Walk;
                    _animator.SetBool("Near", false);
                }
                else if (_playerSeen)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("Seen", true);
                }
                break;
        }
    }
}
