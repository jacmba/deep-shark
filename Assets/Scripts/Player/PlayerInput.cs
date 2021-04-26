using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  [SerializeField]
  private float speed = 5f;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 translation = new Vector3(h, v, 0) * speed * Time.deltaTime;
    transform.Translate(translation, Space.World);
  }
}
