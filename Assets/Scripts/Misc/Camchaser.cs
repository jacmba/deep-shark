using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camchaser : MonoBehaviour
{
  [SerializeField]
  private Transform target;

  [SerializeField]
  private float speed = 5f;

  private float targetDist;
  private float heightDiff;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    targetDist = target.position.z - transform.position.z;
    heightDiff = Mathf.Abs(target.position.y - transform.position.y);
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (target.position.z - transform.position.z > targetDist + speed * Time.deltaTime)
    {
      transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    if (Mathf.Abs(target.position.y - transform.position.y) > heightDiff + (2 * speed * Time.deltaTime) ||
      transform.position.y < target.position.y)
    {
      Vector3 factor = target.position.y < transform.position.y ? Vector3.down : Vector3.up;
      transform.Translate(factor * speed * 2 * Time.deltaTime, Space.World);
    }

    if (Mathf.Abs(target.position.x - transform.position.x) > 2 * speed * Time.deltaTime)
    {
      Vector3 factor = target.position.x < transform.position.x ? Vector3.left : Vector3.right;
      transform.Translate(factor * speed * 2 * Time.deltaTime, Space.World);
    }
  }
}
