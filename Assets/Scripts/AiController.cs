using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private void Update()
    {
        CheckTransition();
        Behaviour();
    }

    private void Behaviour()
    {
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
                //
                //
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
