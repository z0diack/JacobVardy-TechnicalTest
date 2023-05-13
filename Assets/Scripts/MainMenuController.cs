using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Camera cam;

    [Header("FOV options")]
    public Slider fovSlider;
    public float fovMinValue;
    public float fovMaxValue;
    public Text fovValue;

    [Header("Sensitivity options")]
    public Slider sensSlider;
    public float sensMinValue;
    public float sensMaxValue;
    public Text sensValue;

    void Start()
    {
        //Sets the min/value and the current value for the sensitivity slider.
        sensSlider.minValue = sensMinValue;
        sensSlider.maxValue = sensMaxValue;
        sensSlider.value = cam.GetComponent<PlayerCam>().sens;
        //Adds listener for when the sensitivity slider is updated.
        sensSlider.onValueChanged.AddListener(SensitivityUpdater);

        //Sets the min/value and the current value for the FOV slider.
        fovSlider.minValue = fovMinValue;
        fovSlider.maxValue = fovMaxValue;
        fovSlider.value = cam.GetComponent<Camera>().fieldOfView;
        //Adds listener for when the FOV slider is updated.
        fovSlider.onValueChanged.AddListener(FovUpdater);

    }

    void Update()
    {
        //Update text and rounds the value.
        sensValue.text = Mathf.Round(sensSlider.value/100).ToString();
        fovValue.text = Mathf.Round(fovSlider.value).ToString();
    }

    /// <summary>
    /// Function used to update the sensitivty.
    /// </summary>
    /// <param name="value">value of new sensitivity.</param>
    void SensitivityUpdater(float value)
    {
        cam.GetComponent<PlayerCam>().sens = value;
    }

    /// <summary>
    /// Function used to update the FOV.
    /// </summary>
    /// <param name="value">value of new FOV.</param>
    void FovUpdater(float value)
    {
        cam.GetComponent<Camera>().fieldOfView = value;
    }
}
