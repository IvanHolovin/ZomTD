using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] 
    private GameObject _destinationPoint;

    private GameObject _target;
    
    
    void Start()
    {
        _target = _destinationPoint;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<NavMeshAgent>().destination = _target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = _destinationPoint;
        }
    }
}
