using System;
using UnityEngine;

public class DestroyingObjects : MonoBehaviour
{
  private void Start()
  {
    Destroy(gameObject,16f);
  }

  void OnTriggerEnter(Collider col)
  {
    if (col.CompareTag("DestroyObject"))
    {
      Destroy(gameObject);
    }
  }
}
