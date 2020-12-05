using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarricadeControl : MonoBehaviour
{
    [HideInInspector] public GameLoop GameLoop;

    private bool _isLose = false;

    private void OnTriggerEnter(Collider other)
    {
        _isLose = true;
        GameLoop.ContinueOrLose();
    }
    private void Update()
    {
        if (_isLose == false)
        {
            transform.Translate(Vector3.back * GameLoop.Speed * Time.deltaTime);

            if (transform.position.z <= -0.1)
            {
                GameLoop.Win();
            }
        }
    }
}
