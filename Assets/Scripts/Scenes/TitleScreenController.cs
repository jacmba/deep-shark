using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if (Input.anyKey)
    {
      SceneManager.LoadScene(1);
    }
  }
}
