using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStretcher : MonoBehaviour
{
  [SerializeField]
  private float xSpeed = 20f;

  [SerializeField]
  private float ySpeed = 50f;

  [SerializeField]
  private float maxStretch = 2f;

  [SerializeField]
  private float minStretch = .5f;

  private RectTransform rect;
  private int xStretch = -1;
  private int yStretch = 1;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start()
  {
    rect = GetComponent<RectTransform>();
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    Vector3 scale = rect.transform.localScale;
    scale.x = scale.x + (xSpeed * xStretch * Time.deltaTime);
    scale.y = scale.y + (ySpeed * yStretch * Time.deltaTime);

    if (scale.x <= minStretch)
    {
      xStretch = 1;
    }

    if (scale.x >= maxStretch)
    {
      xStretch = -1;
    }

    if (scale.y <= minStretch)
    {
      yStretch = 1;
    }

    if (scale.y >= maxStretch)
    {
      yStretch = -1;
    }

    rect.transform.localScale = scale;
  }
}
