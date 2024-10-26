using UnityEngine;
using UnityEngine.UI;

public class FeedIn : MonoBehaviour
{
  public CanvasGroup canvasGroup;
  private float speed = 0.01f;
  public static bool _feedin = false;

  void Start()
  {
    // Canvas Group の初期設定（完全に透明にする）
    canvasGroup.alpha = 0f;
  }

  void Update()
  {
    if (Retry._retry)
    {
      if (canvasGroup.alpha != 1)
      {
        canvasGroup.alpha += speed;
      }
      else
      {
        _feedin = true;
        Retry.ReloadScene();
      }
    }
  }
}
