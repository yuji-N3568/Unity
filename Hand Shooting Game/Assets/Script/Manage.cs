using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mediapipe.Unity.Sample.UI;

public class Manage : MonoBehaviour
{

  public static bool Pause = true;
  public static bool Stop = false;
  public static int score;
  public static float time;
  [SerializeField] GameObject Header;
  [SerializeField] GameObject Footer;
  [SerializeField] GameObject Aim;
  [SerializeField] GameObject Finish;
  [SerializeField] GameObject Modal;
  [SerializeField] GameObject Feedin;

  private void Start()
  {
    score = 0;
    time = 30.0f;
    Pause = true;
    Stop = false;
    FinishMenu.finishmenu = true;
    FeedIn._feedin = false;
    Feedin.SetActive(false);
    Modal.SetActive(false);
  }

  // Update is called once per frame
  private void Update()
  {
    if (!Stop)
    {
      if (CountDown.CountFinish)
      {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
          Header.SetActive(Pause);
          Footer.SetActive(Pause);
          //Aim.SetActive(!Pause);
          Pause = !Pause;
        }
        else if (Pause)
        {
          if (time > 0)
          {
            time -= Time.deltaTime;
            GetComponent<TextMeshProUGUI>().text = "Time:" + time.ToString("F2") + "    Score:" + score.ToString("D2");
          }
          else
          {
            time = 0;
            GetComponent<TextMeshProUGUI>().text = "Time:00.00" + "    Score:" + score.ToString("D2");
            Stop = true;
          }
        }
      }
    }
    else
    {
      Header.SetActive(!Stop);
      Footer.SetActive(!Stop);
      Finish.SetActive(FinishMenu.finishmenu);
    }
    Feedin.SetActive(Retry._retry);
  }
}
