using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 _nextDirection = default;
    [SerializeField] private Rigidbody _rigidbody = default;
    [SerializeField] private float _jumpForce = 50;
    [SerializeField] private Vector3 _currentPosition = default;
    [SerializeField] private float _speed = 10;
    [SerializeField] private GameObject _sceneManager = default;
    [SerializeField] private float _rotationSpeed = 1000;
    [SerializeField] private float _counter = default;
    [SerializeField] private Text _score = default;
    [SerializeField] private float HighScore = 0;
    [SerializeField] private AudioSource _audioSource = default;
    [SerializeField] private AudioClip[] _audioClips = default;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentPosition = transform.position;
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (transform.position != new Vector3(_currentPosition.x, transform.position.y, _currentPosition.z) + _nextDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentPosition.x, transform.position.y, _currentPosition.z) + _nextDirection, _speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_nextDirection), _rotationSpeed * Time.deltaTime);
        }
        else
        {
            _nextDirection = Vector3.zero;
            _currentPosition = transform.position;
            _currentPosition.x = Mathf.Round(_currentPosition.x);
            _currentPosition.z = Mathf.Round(_currentPosition.z);
            GetAxis();
        }
        if (HighScore < _counter)
        {
            HighScore = _counter;
            _audioSource.Play();
        }
        _score.text = HighScore.ToString("0");
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
            _counter += _nextDirection.z;
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
            Destroy(gameObject);
        }
    }
}
