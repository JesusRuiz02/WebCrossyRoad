
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = default;
    [SerializeField] private bool direction = default;
    
    void Update()
    {
        MovDir();
    }

    private void MovDir()
    {
        var dir = direction ? transform.right : -transform.right;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
