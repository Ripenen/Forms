using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FormControl : MonoBehaviour
{
    private bool isLose = false;

    private void Update()
    {
        RotateForm();
    }
    private void RotateForm()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var pos = (Vector3)touch.position;
            pos.z = Vector2.Distance(transform.position, Camera.main.transform.position);

            Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(pos);

            if (touch.phase == TouchPhase.Moved && isLose == false)
            {

                if (TouchPosition.y <= 0.05f)
                {
                    transform.Rotate(0, 0, touch.deltaPosition.x * 0.4f, Space.World);
                }
                else
                {
                    transform.Rotate(0, 0, -touch.deltaPosition.x * 0.4f, Space.World);
                }
            }

        }
    }
}
