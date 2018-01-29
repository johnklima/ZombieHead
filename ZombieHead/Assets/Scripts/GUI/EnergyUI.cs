using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Text energyText; // The energy remaining.
    public Slider speedSlider;
    float motionEnergy;
    public PlayerMotion playerMotion;

    // Use this for initialization
    void Start()
    {
        motionEnergy = 0; // Currently redundant, but I'm expecting that we'll want to truncate it, and potentially do math with it first.
        energyText.text = "Energy Full";
    }

    // Update is called once per frame
    void Update()
    {
        motionEnergy = playerMotion.energy;
        energyText.text = "Energy Remaining: " + motionEnergy; // Not part of the request, but was useful during debugging and I'll leave it until we know more about how the design will look. Possibly add '+ maxEnergy' (after defining that) if we want the max to change.
        speedSlider.value = motionEnergy;
    }
}