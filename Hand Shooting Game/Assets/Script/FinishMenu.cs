using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
  private CanvasGroup canvasGroup;
  [SerializeField] GameObject finish;

  void Start()
  {
    canvasGroup = GetComponent<CanvasGroup>();

    if (canvasGroup == null)
    {
      Debug.LogWarning("CanvasGroup が設定されていません");
    }
  }

  // Canvasの表示・非表示を切り替えるメソッド
  public void ToggleCanvasVisibility()
  {
    finish.SetActive(false);
  }
}
