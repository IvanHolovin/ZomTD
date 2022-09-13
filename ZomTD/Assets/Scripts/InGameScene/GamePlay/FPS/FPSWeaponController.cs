using System.Collections;
using System.Collections.Generic;
using InGameScene.GamePlay;
using UnityEngine;

public class FPSWeaponController : MonoBehaviour
{
    [SerializeField] 
    private Weapon _pistol;

    [SerializeField] 
    private Weapon _shotgun;


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _pistol.gameObject.SetActive(true);
            _shotgun.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _pistol.gameObject.SetActive(false);
            _shotgun.gameObject.SetActive(true);
        }
    }

}
