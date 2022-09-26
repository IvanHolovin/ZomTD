using InGameScene.GamePlay;
using UnityEngine;

public class FPSWeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _pistol;
    [SerializeField] private Weapon _shotgun;

    private Weapon _currentWeapon;

    private void Awake()
    {
        SetPistol();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetPistol();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetShotgun();
        }

        if (Input.GetButton("Fire1"))
        {
            _currentWeapon.Fire();
        }
    }

    private void SetPistol()
    {
        _pistol.gameObject.SetActive(true);
        _shotgun.gameObject.SetActive(false);
        _currentWeapon = _pistol;
    }

    private void SetShotgun()
    {
        _pistol.gameObject.SetActive(false);
        _shotgun.gameObject.SetActive(true);
        _currentWeapon = _shotgun;
    }

}
