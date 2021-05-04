using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField]
  private EnemyType type;

  [SerializeField]
  private int health = 5;

  [SerializeField]
  private State[] states;
  private int stateIndex;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    stateIndex = 0;
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
  }
}
