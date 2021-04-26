using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
  [SerializeField]
  private float speed = 20f;
  private Transform aim;

  // Start is called before the first frame update
  void Start()
  {
    aim = Aim.instance;
    transform.LookAt(aim, Vector3.down);
    transform.Rotate(Vector3.right * 90f);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.up * speed * Time.deltaTime);
  }

  /// <summary>
  /// OnCollisionEnter is called when this collider/rigidbody has begun
  /// touching another rigidbody/collider.
  /// </summary>
  /// <param name="other">The Collision data associated with this collision.</param>
  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag != "Player")
    {
      GameObject.Destroy(gameObject);
    }
  }
}
