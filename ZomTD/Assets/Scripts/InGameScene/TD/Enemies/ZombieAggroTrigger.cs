using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAggroTrigger : MonoBehaviour
{
    private bool _following;
    public bool Following => _following;

    private GameObject _target;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
            _following = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _following = false;
        }
    }
    
    public GameObject FollowPlayer()
    {
        return _target;
    }
}
