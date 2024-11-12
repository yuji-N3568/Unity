using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Clone : MonoBehaviour
{
  public GameObject target;
  private int Count = 30;
  // Start is called before the first frame update

  // Update is called once per frame
  void Update()
  {
    if (Manage.time < Count)
    {
      Instantiate(target, new Vector3(0, -150, 100), Quaternion.Euler(-90, 0, 0));
      Count -= (int)Count / 10 + 1;
    }
  }
}
