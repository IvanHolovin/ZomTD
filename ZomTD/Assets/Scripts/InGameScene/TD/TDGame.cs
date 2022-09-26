using UnityEngine;

public class TDGame : MonoBehaviour
{
    [SerializeField] private Vector2Int _boardSize;
    [SerializeField] private TilesBoard[] _tilesBoards;
    
    void Start()
    {
        foreach (var boards in _tilesBoards)
        {
            boards.Initialize(_boardSize);
        }
    }
}
