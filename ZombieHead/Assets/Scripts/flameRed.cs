using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameRed : MonoBehaviour
{

    public float timer2;

    private Light lighRed;

    private float waitTime1 = 1;

    private void Start()
    {
        timer2 = Time.time;

        lighRed = transform.GetComponent<Light>();
    }
    private void Update()
    {
        if (Time.time - timer2 > waitTime1)
        {
            timer2 = Time.time;
            waitTime1 = Random.RandomRange(0.05f, 0.1f);

            lighRed.enabled = !lighRed.enabled;

        }

    }

}