using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
  public Button myButton;
  public static bool _retry = false;

  void Start()
  {
    // ボタンのクリックイベントにメソッドを追加
    myButton.onClick.AddListener(ReloadScene);
  }

  public static void ReloadScene()
  {
    // 現在のシーンを再読み込み
    if (FeedIn._feedin)
    {
      _retry = false;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    else
    {
      _retry = true;
    }
  }
}
