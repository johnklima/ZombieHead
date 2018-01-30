using System.Collections;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{

    public float timer;

    private Light light;

    private float waitTime = 1;

    private void Start()
    {
        timer = Time.time;

        light = transform.GetComponent<Light>();
    }
    private void Update()
    {

        if (Time.time - timer > waitTime)
        {
            timer = Time.time;
            waitTime = Random.RandomRange(0.5f, 2.0f);

            light.enabled = !light.enabled;

        }



    }



}