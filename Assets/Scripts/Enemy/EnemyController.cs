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

  private State currentState;

  private Animator animator;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    stateIndex = 0;
    animator = GetComponent<Animator>();
    SetState();
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (currentState.angle != Vector3.zero && Magnitude(currentState.angle - transform.eulerAngles) > 1f)
    {
      Debug.Log(Magnitude(currentState.angle - transform.eulerAngles));
      transform.Rotate(currentState.angle * currentState.rotSpeed * Time.deltaTime, Space.Self);
    }

    if (currentState.speed > 0f)
    {
      transform.Translate(Vector3.up * currentState.speed * Time.deltaTime, Space.Self);
    }
  }

  void SetState()
  {
    currentState = states[stateIndex];
    animator.SetInteger("State", (int)currentState.type);
  }

  float Magnitude(Vector3 v)
  {
    return Mathf.Abs(v.x + v.y + v.z);
  }
}
