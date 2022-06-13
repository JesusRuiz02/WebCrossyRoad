
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _nextDirection = default;
    [SerializeField] private Rigidbody _rigidbody = default;
    [SerializeField] private float _jumpForce = 100;
    [SerializeField] private Vector3 _currentPosition = default;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _sceneManager;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentPosition = transform.position;
    }
    void Update()
    {
        if (transform.position != new Vector3(_currentPosition.x, transform.position.y, _currentPosition.z) + _nextDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentPosition.x, transform.position.y, _currentPosition.z) + _nextDirection, _speed * Time.deltaTime);
        }
        else
        {
            _nextDirection = Vector3.zero;
            _currentPosition = transform.position;
        }
        GetAxis();
    }
    private void GetAxis()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _nextDirection.x = Input.GetAxisRaw("Horizontal");
            Move();
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            _nextDirection.z = Input.GetAxisRaw("Vertical");
            Move();
        }
    }
    private void Move()
    {
        _rigidbody.AddForce(0,_jumpForce,0);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        { 
            _sceneManager.GetComponent<SceneMnager>().ActivateCanvas();
        }
    }
}
