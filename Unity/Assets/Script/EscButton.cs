using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscButton : MonoBehaviour
{
  public Button targetButton;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (targetButton != null)
      {
        targetButton.onClick.Invoke();
      }
      else
      {
        Debug.LogWarning("targetButton が設定されていません");
      }
    }
  }
}
