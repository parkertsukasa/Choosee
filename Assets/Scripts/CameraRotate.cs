using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

  [SerializeField]
  private JoyStick _joystick = null;

  [SerializeField]
  private float speed = 1.0f;

  [SerializeField]
  GameObject camera;

  bool fp = false;
  bool fp_init = false;

  [SerializeField]
  GameObject destination;


  [SerializeField]
  GameObject player;
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    camera.transform.Rotate(Vector3.up * speed * _joystick.Position.x);
    camera.transform.Rotate(Vector3.right * -speed * _joystick.Position.y);

    if (fp)
    {
      Vector3 pos = new Vector3(0, 300, 0);
      camera.transform.LookAt(player.transform.position);
      camera.transform.position = pos;
      fp_init = false;
    }
    else
    {
      Vector3 pos = new Vector3(0, 2, 0);
      camera.transform.position = pos;
      if (!fp_init)
      {
				destination = GameObject.Find("Destin");
        camera.transform.LookAt(destination.transform.position);
        fp_init = true;
      }
    }
  }

  public void CameraChanger()
  {
    fp = !fp;
  }
}
