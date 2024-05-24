using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IAPerception : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pawn;
    private Vector3 checkDirection;
    [SerializeField] private float distance;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void CheckDistance()
    {
        checkDirection = _player.transform.position - _pawn.transform.position;
        RaycastHit hit;

        if(Physics.Raycast(_pawn.transform.position,checkDirection,out hit, distance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                _pawn.GetComponentInChildren<AiController>().PlayerNear = true;
            }
            else
            {
                _pawn.GetComponentInChildren<AiController>().PlayerNear = false;
            }
        }
        else
        {
            _pawn.GetComponentInChildren<AiController>().PlayerNear = false;
        }
    }
}
