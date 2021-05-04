using System;
using UnityEngine;

[Serializable]
public class State
{
  public StateType type;
  public float speed;
  public Vector3 angle;
  public float rotSpeed;
  public float minDist;
}
