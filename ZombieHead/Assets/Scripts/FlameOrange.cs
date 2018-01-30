using System.Collections;
using UnityEngine;

public class FlameOrange : MonoBehaviour
{

    public float timer1;

    private Light lighOrange;

    private float waitTime1 = 1;

    private void Start()
    {
        timer1 = Time.time;

        lighOrange = transform.GetComponent<Light>();
    }
    private void Update()
    {
        if (Time.time - timer1 > waitTime1)
        {
            timer1 = Time.time;
            waitTime1 = Random.RandomRange(0.05f, 0.1f);

            lighOrange.enabled = !lighOrange.enabled;

        }

    }

}