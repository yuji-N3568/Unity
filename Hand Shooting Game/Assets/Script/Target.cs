using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Target : MonoBehaviour
{
  // Start is called before the first frame update

  private float speed = 0.4f;
  private Vector3 TargetPos;
  private Vector2 distance;
  private AudioSource audiosource;

  void Start()
  {
    TargetPos = new Vector3(Random.Range(-105.0f, 105.0f), -145, 110);
    transform.position = TargetPos;
  }

  // Update is called once per frame
  void Update()
  {
    if (Manage.Pause && !Manage.Stop)
    {
      if (TargetPos.y < 16.5)
      {
        if (AimScript.trigger)
        {
          distance.x = TargetPos.x - AimScript.AimPos.x;
          distance.y = TargetPos.y - AimScript.AimPos.y + 64.5f;
          if (Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y) < 15)
          {
            audiosource.Play();
            Manage.score += 1;
            Destroy(gameObject);
          }
        }
        TargetPos.y = TargetPos.y + speed;
        transform.position = TargetPos;
      }
      else
      {
        Destroy(gameObject);
      }
    }
  }
}
