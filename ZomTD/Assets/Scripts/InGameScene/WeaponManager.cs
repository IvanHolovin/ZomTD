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

    // Update is called once per frame
    void Update()
    {
        _currentWeapon.Targeting();
        
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWeapon.Shot();
        }
    }

    private void Shoot()
    {
        Tile targetTile = GetTile();
        if(targetTile != null){
            currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
            targetTile._TileType = Tile.TileType.Wall;
            if (currentPathFinder.PathFind())
            {
                targetTile._TileType = Tile.TileType.Wall;
                Debug.Log("open");
            }
            else
            {
                targetTile._TileType = Tile.TileType.Open;
                Debug.Log("closed");
            }
        }
        
    }


    private Tile GetTile()
    {
        //Ray ray = _playerCam.transform.position,;
        RaycastHit rayHit;
        bool wasHit = Physics.Raycast(_playerCam.transform.position,_playerCam.transform.forward, out rayHit, int.MaxValue, LayerMask.GetMask("Tiles"));
        if (wasHit)
            return rayHit.transform.GetComponent<Tile>();
        else
            return null;
    }
}
