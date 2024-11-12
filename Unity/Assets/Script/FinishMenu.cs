using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{  private void Update()
  {
    // 常に最背面に設定
    transform.SetAsFirstSibling();
  }
}
