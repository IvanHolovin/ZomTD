using UnityEngine;

namespace InGameScene.Weapons
{
    public class AIM : MonoBehaviour
    {
        [SerializeField] private GameObject _playerCamera;
        
        public GameObject Target(int range)
        {
            RaycastHit rayHit;
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out rayHit,
                range, ~12))
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