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
  public static bool Finishnow = false;
  public static int score;
  public static float time;
  public AudioSource bgmSource;
  public AudioSource seSource;
  public AudioSource clickSE;
  public AudioSource balloonSE;
  public AudioSource FinishSE;
  private bool pastmodal;
  private int pastscore;
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
    Finishnow = false;
    FeedIn._feedin = false;
    Feedin.SetActive(false);
    Modal.SetActive(false);
    bgmSource.Stop(); 
    pastmodal = false;
    pastscore = 0;
  }

  // Update is called once per frame
  private void Update()
  {
    if (!Stop)
    {
      if (CountDown.CountFinish)
      {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          bgmSource.Pause();
          seSource.Play();
          Header.SetActive(Pause);
          Footer.SetActive(Pause);
          //Aim.SetActive(!Pause);
          Pause = !Pause;
        }
        else if (Pause)
        {
          if (time > 0)
          {
            if (!bgmSource.isPlaying)
            {
              bgmSource.Play();
            }
            time -= Time.deltaTime;
            GetComponent<TextMeshProUGUI>().text = "Time:" + time.ToString("F2") + "    Score:" + score.ToString("D2");
            if(pastscore != score)
            {
              pastscore = score;
              balloonSE.Play();

            }
          }
          else
          {
            time = 0;
            GetComponent<TextMeshProUGUI>().text = "Time:00.00" + "    Score:" + score.ToString("D2");
            FinishSE.Play();
            Stop = true;
          }
        }
      }
    }
    else
    {
      Finishnow = true;
      Header.SetActive(!Stop);
      Footer.SetActive(!Stop);
      bgmSource.Stop();
      Finish.SetActive(!Modal.activeSelf);
    }
    Feedin.SetActive(Retry._retry);
    if (Modal.activeSelf != pastmodal && !Input.GetKey(KeyCode.Escape))
    {
      clickSE.Play();
    }
    pastmodal = Modal.activeSelf;
  }
}
