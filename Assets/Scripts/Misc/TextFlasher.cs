using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlasher : MonoBehaviour
{
  [SerializeField]
  private float limit = .25f;

  private float counter = 0f;
  private Text text;

  // Start is called before the first frame update
  void Start()
  {
    text = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update()
  {
    counter += Time.deltaTime;
    if (counter >= limit)
    {
      text.enabled = !text.enabled;
      counter = 0;
    }
  }
}
