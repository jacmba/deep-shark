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
  private Vector3 velocity;
  private PlayerController player;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    stateIndex = 0;
    velocity = Vector3.zero;
    animator = GetComponent<Animator>();
    SetState();
    player = PlayerController.instance;
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (player == null)
    {
      player = PlayerController.instance;
    }

    if (currentState.angle != Vector3.zero)
    {
      Quaternion rot = Quaternion.Euler(currentState.angle);
      transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * currentState.rotSpeed);
    }

    if (velocity.magnitude > 0f)
    {
      transform.Translate(velocity * Time.deltaTime, Space.World);
      if (currentState.type == StateType.SWIM)
      {
        velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime);
      }
    }

    float dist = Mathf.Abs(transform.position.z - player.transform.position.z);
    if (dist < currentState.minDist)
    {
      NextState();
    }
  }

  void SetState()
  {
    currentState = states[stateIndex];
    animator.SetInteger("State", (int)currentState.type);
    Advance();
  }

  void NextState()
  {
    stateIndex++;
    if (stateIndex < states.Length)
    {
      SetState();
    }
  }

  void Advance()
  {
    velocity = currentState.velocity;
  }
}
