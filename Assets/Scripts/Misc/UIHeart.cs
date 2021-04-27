using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
  [SerializeField]
  private int number;

  private Image image;

  // Start is called before the first frame update
  void Start()
  {
    image = GetComponent<Image>();
  }

  // Update is called once per frame
  void Update()
  {
    image.enabled = PlayerController.lives >= number;
  }
}
