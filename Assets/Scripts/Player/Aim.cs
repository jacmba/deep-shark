using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
  [SerializeField]
  public static Transform instance { get; private set; }

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    instance = transform;
  }
}
