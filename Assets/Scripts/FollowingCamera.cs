
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset = default;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(_player.transform.position.x + _offset.x,
            _player.transform.position.y + _offset.y, _player.transform.position.z + _offset.z);
    }
    void Update()
    {
        if (_player!=null)
        {
            transform.position = new Vector3(_player.transform.position.x + _offset.x, _offset.y, _player.transform.position.z + _offset.z);
        }
        
    }
}

