using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

  // シーンインデックスでシーンをロードします
  public void ChangeScene(int sceneIndex)
  {
    SceneManager.LoadScene(sceneIndex);
  }

  public void OnButtonClick()
  {
    var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    var NextSceneIndex = 1 - CurrentSceneIndex;
   ChangeScene(NextSceneIndex);
  }
}
