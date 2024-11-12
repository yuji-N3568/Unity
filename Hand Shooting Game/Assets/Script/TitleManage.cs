using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManage : MonoBehaviour
{
  public GameObject modal;
  public Canvas titlemenu;
  public AudioSource clickSE;
  private bool pastactive=false;
  void Update()
  {
    if (!modal.activeSelf)
    {
      titlemenu.sortingOrder = 1;
    }
    else
    {
      titlemenu.sortingOrder = -1;
    }
    if(pastactive != modal.activeSelf)
    {
      clickSE.Play();
      pastactive = modal.activeSelf;
    }
  }
}
