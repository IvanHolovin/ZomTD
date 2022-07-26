using System;
using UnityEngine;

namespace InGameScene.Weapons
{
    public class AIM : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _playerCamera;
        
        public GameObject Target()
        {
            RaycastHit rayHit;
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out rayHit,
                int.MaxValue))
            {
                return rayHit.transform.gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}