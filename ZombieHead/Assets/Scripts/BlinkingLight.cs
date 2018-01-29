using System.Collections;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{

    public float Seconds;    
    public float Intensity;     
    public Light myLight;

    public IEnumerator GetFlashNow()
    {
        float waitTime = Seconds / 2;

        while (myLight.intensity < Intensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;
            yield return null;
        }
        yield return null;
    }
}