using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvance : MonoBehaviour
{
  [SerializeField]
  private float speed = 2f;

  private bool advance;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    advance = true;
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (advance)
    {
      transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }
  }

  public void Advance()
  {
    advance = true;
  }

  public void Stop()
  {
    advance = false;
  }
}
