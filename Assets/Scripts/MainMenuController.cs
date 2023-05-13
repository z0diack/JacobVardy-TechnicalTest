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


    // Start is called before the first frame update
    void Start()
    {
        sensSlider.minValue = sensMinValue;
        sensSlider.maxValue = sensMaxValue;
        sensSlider.value = cam.GetComponent<PlayerCam>().sens;

        sensSlider.onValueChanged.AddListener(SensitivityUpdater);

        fovSlider.minValue = fovMinValue;
        fovSlider.maxValue = fovMaxValue;
        fovSlider.value = cam.GetComponent<Camera>().fieldOfView;

        fovSlider.onValueChanged.AddListener(FovUpdater);

    }

    // Update is called once per frame
    void Update()
    {
        sensValue.text = Mathf.Round(sensSlider.value/100).ToString();
        fovValue.text = Mathf.Round(fovSlider.value).ToString();
    }

    void SensitivityUpdater(float value)
    {
        cam.GetComponent<PlayerCam>().sens = value;
    }

    void FovUpdater(float value)
    {
        cam.GetComponent<Camera>().fieldOfView = value;
    }
}
