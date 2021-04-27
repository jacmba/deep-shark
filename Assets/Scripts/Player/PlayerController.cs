using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public static int lives = 3;

  private SpriteStretcher stretcher;
  private AudioSource audioSource;
  private AudioClip damageSound;
  private bool canDamage = false;
  private float damageClock = 3f;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    damageSound = Resources.Load<AudioClip>("Sound/damage");
    stretcher = GetComponent<SpriteStretcher>();
    audioSource = GetComponent<AudioSource>();
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (canDamage)
    {
      stretcher.enabled = false;
    }
    else
    {
      stretcher.enabled = true;
      damageClock -= Time.deltaTime;
      if (damageClock <= 0)
      {
        damageClock = 3f;
        canDamage = true;
      }
    }
  }

  /// <summary>
  /// OnCollisionEnter is called when this collider/rigidbody has begun
  /// touching another rigidbody/collider.
  /// </summary>
  /// <param name="other">The Collision data associated with this collision.</param>
  void OnCollisionEnter(Collision other)
  {
    if (canDamage)
    {
      audioSource.clip = damageSound;
      audioSource.Play();
      damageClock = 5f;
      lives--;
      transform.position = new Vector3(0, 0, transform.position.z);
      canDamage = false;
    }
  }
}
