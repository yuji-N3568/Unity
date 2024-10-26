using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
  public Button myButton;
  public static bool finishmenu;

  void Start()
  {
    myButton.onClick.AddListener(FinishConfig);
  }

  public void FinishConfig()
  {
    finishmenu = !finishmenu;
  }
}
