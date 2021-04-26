using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  [SerializeField]
  private float speed = 5f;

  private Transform aim;
  private float aimDist;
  private bool canShoot;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    aim = Aim.instance;
    aimDist = aim.position.z - transform.position.z;
    canShoot = true;
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
    transform.LookAt(aim.position, Vector3.down);
    transform.Rotate(Vector3.right * 90f);

    if (Input.GetButton("Fire1"))
    {
      if (canShoot)
      {
        OnLaserShoot?.Invoke();
        canShoot = false;
      }
    }
    else
    {
      canShoot = true;
    }
  }

  /// <summary>
  /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  /// </summary>
  void FixedUpdate()
  {
    Vector3 point = new Vector3(Input.mousePosition.x, Input.mousePosition.y, aimDist);
    Vector3 lookPos = Camera.main.ScreenToWorldPoint(point);

    RaycastHit hit;
    bool touched = Physics.Raycast(transform.position, lookPos - transform.position, out hit, 200f);
    if (touched)
    {
      aim.position = hit.point;
    }
    else
    {
      aim.position = new Vector3(lookPos.x, lookPos.y, transform.position.z + aimDist);
    }
  }

  public static event Action OnLaserShoot;
}