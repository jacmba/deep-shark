using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
  private GameObject laserPrefab;
  private AudioSource audioSrc;

  /// <summary>
  /// Start is called before the first frame update
  /// </summary>
  void Start()
  {
    laserPrefab = Resources.Load<GameObject>("Prefabs/Laser");
    audioSrc = GetComponent<AudioSource>();
    PlayerInput.OnLaserShoot += OnLaserShoot;
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy()
  {
    PlayerInput.OnLaserShoot += OnLaserShoot;
  }

  void OnLaserShoot()
  {
    GameObject.Instantiate(laserPrefab, transform.position, transform.rotation);
    audioSrc.Play();
  }
}
