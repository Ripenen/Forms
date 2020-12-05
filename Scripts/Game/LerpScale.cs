using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector2(Mathf.PingPong(Time.time * 0.25f, 1.25f - 1f) + 1f, Mathf.PingPong(Time.time * 0.25f, 1.25f - 1f) + 1f);
    }
}
