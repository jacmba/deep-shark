using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  [SerializeField]
  private float speed = 15.0f;

  [SerializeField]
  private Vector3 axis = Vector3.up;

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    transform.Rotate(axis * speed * Time.deltaTime);
  }
}
