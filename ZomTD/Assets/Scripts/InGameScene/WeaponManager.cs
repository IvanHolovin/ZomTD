using System.Collections;
using System.Collections.Generic;
using InGameScene.Weapons;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _playerCam;
    
    private IWeapon _currentWeapon;

    [SerializeField] 
    private GameObject _weapon;

    private PathFinding currentPathFinder;

    public GameObject PlayerCam() => _playerCam;

    void Start()
    {
        _currentWeapon = _weapon.GetComponent<IWeapon>();
    }
    
    void Update()
    {
        _currentWeapon.Targeting();
        
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWeapon.Shot();
        }

        if (Input.GetButtonDown("Reload"))
        {
            _currentWeapon.Reload();
        }
        
    }
}
