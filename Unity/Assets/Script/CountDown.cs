using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CountDown : MonoBehaviour
{
  public static int Count = 3;
  public static bool CountFinish = false;
  public AudioSource audioSource;

  // Start is called before the first frame update
  void Start()
  {
    CountFinish = false;
    StartCoroutine(myCourutine());
  }

  // Update is called once per frame
  IEnumerator myCourutine()
  {
    for (Count = 3; Count > 0; Count--)
    {
      GetComponent<TextMeshProUGUI>().text = Count.ToString("D1");
      audioSource.Play();
      yield return new WaitForSeconds(1);
    }
    CountFinish = true;
    gameObject.SetActive(false);
  }
}
