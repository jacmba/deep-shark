using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStretcher : MonoBehaviour
{
  [SerializeField]
  private float speed = 15f;

  [SerializeField]
  private float minStrecth = 0.75f;

  [SerializeField]
  private float maxStretch = 1.5f;

  private float stretch = 1f;
  private int factor = 1;
  private Vector3 size;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    size = transform.localScale;
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    transform.localScale = size * stretch;
    stretch += factor * speed * Time.deltaTime;
    if (stretch >= maxStretch)
    {
      factor = -1;
    }
    else if (stretch <= minStrecth)
    {
      factor = 1;
    }
  }
}
