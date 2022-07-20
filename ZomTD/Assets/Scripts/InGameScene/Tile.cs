using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        Open,
        Wall,
        Locked,
        StartPoint,
        EndPoint
    }
    
    [SerializeField] 
    private Transform _gameTile;

    [SerializeField] 
    private Transform _arrow;

    [SerializeField] 
    private GameObject _box;

    [SerializeField] 
    private GameObject _lightBox;
    
    private TileType _tileType;
    
    private int _x;
    private int _y;
    
    public int _X => _x; 
    public int _Y => _y;
    
    public TileType _TileType
    {
        get => _tileType;
        set
        {
            _tileType = value;
            switch (_tileType)
            {
                case TileType.Open:
                    _box.gameObject.SetActive(false);
                    break;
                case TileType.Wall:
                    _box.gameObject.SetActive(true);
                    break;
                case TileType.Locked:
                    _box.gameObject.SetActive(false);
                    break;
            }
        }
    }
    
    public void Init(int xPos, int yPos)
    {
        _x = xPos;
        _y = yPos;
    }
    
    
}
