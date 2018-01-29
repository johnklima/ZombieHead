using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindUI : MonoBehaviour
{
    // public Text windLabel; // Currently it's just a label. But if we want to make the numbers more transparent we could put raw numbers here.
    public Slider WindSlider; // z, blue, right
    public Slider NWindSlider; // -z, red, left
    float windEnergy; // Positive wind
    float windEnergyN; // Negative wind
    public PlayerMotion playerMotion; // Or wherever we get the windForce

    // Use this for initialization
    void Start()
    {
        WindSlider.value = 0;
        NWindSlider.value = 0;
        // windLabel.text = "Wind Neutral"; // Whatever we want to have as the starting label.
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMotion.windForce.z <= 0) //If the wind needs 'fixing'
        {
            WindSlider.value = 0; // Resetting it in case we do sudden jumps.
            NWindSlider.value = playerMotion.windForce.z * -1;
        }
        else //If the wind is already positive.
        {
            NWindSlider.value = 0; // Resetting it in case we do sudden jumps.
            WindSlider.value = playerMotion.windForce.z;
        }
        //windLabel.text = "Update text goes here" + playerMotion.windForce.z; // Whatever we want it to update to.
    }
}