
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstance = default;
    [SerializeField] private float spawnRate = 3f;
    void Start()
    {
        RepeatInvoke();
    }

    private void RepeatInvoke()
    {
        InvokeRepeating("CreateObjects",0f,spawnRate);
    }

    private void CreateObjects()
    {
        Instantiate(objectToInstance, transform.position, transform.rotation);
    }

}
