using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject playerCam;

    private PathFinding currentPathFinder;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Tile targetTile = GetTile();
        if(targetTile != null){
            currentPathFinder = targetTile.GetComponentInParent<PathFinding>();
            targetTile._TileType = Tile.TileType.Wall;
            if (currentPathFinder)
            {
                targetTile._TileType = Tile.TileType.Open;
                Debug.Log("open");
            }
        }
        
    }


    private Tile GetTile()
    {
        //Ray ray = playerCam.transform.position,;
        RaycastHit rayHit;
        bool wasHit = Physics.Raycast(playerCam.transform.position,playerCam.transform.forward, out rayHit, int.MaxValue, LayerMask.GetMask("Tiles"));
        if (wasHit)
            return rayHit.transform.GetComponent<Tile>();
        else
            return null;
    }
}
