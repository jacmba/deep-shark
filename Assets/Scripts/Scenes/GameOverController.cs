using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

  [SerializeField]
  private Text text;

  [SerializeField]
  private float fadeSpeed = 2f;

  [SerializeField]
  private float counter = 3f;

  private float fade = 0f;

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (fade < 1)
    {
      fade = Mathf.Lerp(fade, 1f, fadeSpeed * Time.deltaTime);
      text.color = new Color(text.color.r, text.color.g, text.color.b, fade);
    }

    counter -= Time.deltaTime;
    if (counter <= 0f)
    {
      SceneManager.LoadScene(0);
    }
  }
}
