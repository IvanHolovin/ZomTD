using UnityEngine;

namespace InGameScene.TD.Boards.Tiles
{
    public class Tile : MonoBehaviour
    {
        public enum TileType
        {
            Open,
            NotOpen,
            Wall,
            Locked,
        }
        
        [SerializeField] private GameObject _tilePlate;
        [SerializeField] private ParticleSystem _particle;
        
        private TileSelector _selector;
        private ParticleSystem.MainModule _particleMain;
        private Color _red = new Color(255,0,0,255);
        private Color _blue = new Color(0, 255, 250, 255);
        private TileType _tileType;
        private int _x;
        private int _y;
        private GameTileContent _content;
        private GameTileContent _savedContent;
        private GameTileContent _previewContent;
        private bool _isSelected;
    
        public int _X => _x; 
        public int _Y => _y;
        public GameTileContent Content
        {
            get => _content;
            set
            {
                if (_content != null)
                {
                    _content.Recycle();
                }

                _content = value;
                TransformAndScaleContent(ref _content);
                
                DeselectThisTile();
            }
        }
        public GameTileContent PreviewContent
        {
            get => _previewContent;
            set
            {
                if (_previewContent != null)
                {
                    _previewContent.Recycle();
                }
                _previewContent = value;
                TransformAndScaleContent(ref _previewContent);
            }
        }
        public TileType CurrentTileType
        {
            get => _tileType;
            set
            {
                _tileType = value;
                switch (_tileType)
                {
                    case TileType.Open:
                        _particleMain.startColor = _blue;
                        break;
                    case TileType.NotOpen:
                        _particleMain.startColor = _red;
                        break;
                    case TileType.Wall:
                        _particleMain.startColor = _blue;
                        break;
                    case TileType.Locked:
                        _tilePlate.gameObject.SetActive(false);
                        break;
                }
            }
        }
        
        private void Start()
        {
            _selector = GetComponentInParent<TileSelector>();
            _selector.RegisterTile(this);
            _particleMain = _particle.main;
        }
        
        private void OnDestroy()
        {
            _selector.UnRegisterTile(this);
        }
        
        private void TransformAndScaleContent(ref GameTileContent content)
        {
            var transform1 = content.transform;
            transform1.parent = transform;
            transform1.localScale = new Vector3(1, transform.localScale.x, 1);
            transform1.localPosition = new Vector3(0f,0f,transform.localScale.x/2);
        }

        private void Highlight(bool state)
        {
            _particle.gameObject.SetActive(state && _tileType != TileType.Locked);
        }

        public void SelectThisTile()
        {
            if (_tileType != TileType.Locked)
            {
                Highlight(true);
                _isSelected = true;
                _content.gameObject.SetActive(false);
            }
        }

        public void DeselectThisTile()
        {
            if (_tileType != TileType.Locked)
            {
                Highlight(false);
                if (_isSelected)
                {
                    _isSelected = false;
                    _content.gameObject.SetActive(true);
                    _previewContent.gameObject.SetActive(false);
                }
            }
        }

        public void ShowPreviewContent()
        {
            _previewContent.gameObject.SetActive(true);
        }
        
        public void Init(int xPos, int yPos)
        {
            _x = xPos;
            _y = yPos;
        }
    }
}
