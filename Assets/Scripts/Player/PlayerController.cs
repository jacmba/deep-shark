using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public static int lives = 3;

  private SpriteStretcher stretcher;
  private AudioSource audioSource;
  private AudioClip damageSound;
  private bool canDamage = false;
  private float damageClock = 3f;
  private PlayerAdvance advance;
  private Vector3 checkpoint;
  private float checkpointClock = 10f;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    damageSound = Resources.Load<AudioClip>("Sound/damage");
    stretcher = GetComponent<SpriteStretcher>();
    audioSource = GetComponent<AudioSource>();
    advance = GetComponent<PlayerAdvance>();
    checkpoint = transform.position;
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
        advance.Advance();
      }
    }

    checkpointClock -= Time.deltaTime;
    if (checkpointClock <= 0)
    {
      checkpointClock = 10f;
      checkpoint = transform.position;
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
      advance.Stop();
      audioSource.clip = damageSound;
      audioSource.Play();
      damageClock = 5f;
      lives--;

      if (lives < 0)
      {
        SceneManager.LoadScene(2);
      }

      transform.position = new Vector3(0, checkpoint.y, transform.position.z);
      canDamage = false;
    }
  }
}
