using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    
    private Transform _playerTransform;
    private float _xRotation = 0f;
    
    void Start()
    {
        _playerTransform = transform.root.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRotation -= MouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 70f);
        transform.localRotation = Quaternion.Euler(_xRotation,0f,0f);
        _playerTransform.Rotate(Vector3.up * MouseX);
    }
}
