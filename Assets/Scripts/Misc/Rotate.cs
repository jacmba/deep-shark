using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  [SerializeField]
  private float speed = 15.0f;

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    transform.Rotate(Vector3.up * speed * Time.deltaTime);
  }
}
