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
    private GameObject _tileCube;

    [SerializeField] 
    private GameObject _box;

    [SerializeField] 
    private GameObject _lightBox;
    
    [SerializeField] 
    private GameObject _redLightBox;
    
    private TileType _tileType;

    private bool _animationState;
    
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
                    _tileCube.gameObject.SetActive(false);
                    break;
                case TileType.StartPoint:
                    _tileCube.gameObject.SetActive(false);
                    break;
                case TileType.EndPoint:
                    _tileCube.gameObject.SetActive(false);
                    break;
            }
        }
    }
    
    public bool AnimationState { get => _animationState; }
    
    public void Init(int xPos, int yPos)
    {
        _x = xPos;
        _y = yPos;
    }

    public void PlayAnimation(bool animState, bool tileAvailable)
    {
        _animationState = animState;
        _lightBox.gameObject.SetActive(animState && tileAvailable);
        _redLightBox.gameObject.SetActive(animState && !tileAvailable);
        
        
        

        
    }
    
}
