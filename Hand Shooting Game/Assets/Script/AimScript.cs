using Mediapipe.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
  //Ray ray;
  private Vector3 origin;
  private Vector3 rayorigin;
  private Vector3 end;
  private Vector3 direction;
  private Ray ray;
  private RaycastHit hit;
  private bool shot = false;
  private Vector3[] past = new Vector3[4];
  public static bool trigger = false;
  public static Vector3 AimPos = Vector3.zero;

  public void Start()
  {
    for (var i = 0; i < past.Length; i++)
    {
      past[i] = Vector3.zero;
    }
  }

  // Update is called once per frame
  public void Update()
  {
    Debug.Log(transform.position);
    if (!Manage.Stop && Manage.Pause)
    {
      origin = Camera.main.ViewportToWorldPoint(MultiHandLandmarkListAnnotationController.IndexFinger);
      rayorigin = new Vector3(origin.x, origin.y, -10);
      end = Camera.main.ViewportToWorldPoint(MultiHandLandmarkListAnnotationController.ThumbFinger);
      direction = new Vector3(-(end.x - origin.x), -(end.y - origin.y), 30);
      Debug.DrawRay(rayorigin, direction * 4, Color.red, 1 / 60, true);
      ray = new Ray(rayorigin, direction * 4);

      if (Physics.Raycast(ray, out hit))
      {
        transform.position = hit.point;
        for (int i = 1; i < past.Length; i++)
        {
          past[i] = past[i - 1];
        }
        past[0] = transform.position;
        shot = true;
        trigger = false;
      }
      else if (shot)
      {
        transform.position = past[^1];
        AimPos = transform.position;
        trigger = true;
        shot = false;
      }
      else
      {
        trigger = false;
      }
    }
  }
}
