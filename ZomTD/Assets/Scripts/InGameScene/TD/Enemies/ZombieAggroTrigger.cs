using UnityEngine;

public class ZombieAggroTrigger : MonoBehaviour
{
    private bool _isFollowing;
    private GameObject _target;
    
    public bool IsFollowing => _isFollowing;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.gameObject;
            _isFollowing = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isFollowing = false;
        }
    }
    
    public GameObject FollowPlayer()
    {
        return _target;
    }
}
