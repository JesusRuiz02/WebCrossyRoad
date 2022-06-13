
using UnityEngine;

public class DestroyingObjects : MonoBehaviour
{
  void OnTriggerEnter(Collider col)
  {
    if (col.CompareTag("DestroyObject"))
    {
      Destroy(gameObject);
    }
  }
}
