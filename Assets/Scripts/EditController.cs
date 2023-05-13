using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditController : MonoBehaviour
{
    public Camera cam;
    GameObject objEditing;
    GameObject player;

    [Header("Sliders")]
    [SerializeField]
    Slider widthSlider;
    [SerializeField]
    Slider heightSlider;
    [SerializeField]
    Slider scaleSlider;

    [Header("Min/Max Values")]
    [SerializeField]
    float widthMinValue;
    [SerializeField]
    float widthMaxValue;
    [SerializeField]
    float heightMinValue;
    [SerializeField]
    float heightMaxValue;
    [SerializeField]
    float scaleMinValue;
    [SerializeField]
    float scaleMaxValue;

    void Start()
    {
        //Setting the width min/max values.
        widthSlider.maxValue = widthMaxValue;
        widthSlider.minValue = widthMinValue;
        //Adding listener to slider.
        widthSlider.onValueChanged.AddListener(WidthSliderUpdate);

        //Setting height min/max values.
        heightSlider.maxValue = heightMaxValue;
        heightSlider.minValue = heightMinValue;
        //Adding listener to slider.
        heightSlider.onValueChanged.AddListener(HeightSliderUpdate);

        //Setting scale min/max values.
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;
        //Adding listener to slider.
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(objEditing != null)
        {
            widthSlider.value = objEditing.gameObject.transform.localScale.x;
            heightSlider.value = objEditing.gameObject.transform.localScale.y;
        }
    }
    /// <summary>
    /// Width slider update function
    /// Used to change the width of the object editing.
    /// </summary>
    /// <param name="value">Value of the slider.</param>
    void WidthSliderUpdate(float value)
    {
        objEditing.transform.localScale = new Vector3(value, objEditing.transform.localScale.y, value);
    }

    /// <summary>
    /// Height slider update function
    /// Used to change the height of the object editing.
    /// </summary>
    /// <param name="value">Value of the slider.</param>
    void HeightSliderUpdate(float value)
    {
        objEditing.transform.localScale = new Vector3(objEditing.transform.localScale.x, value, objEditing.transform.localScale.z);
    }

    /// <summary>
    /// Scale slider update function
    /// Used to change the scale of the object editing.
    /// </summary>
    /// <param name="value">Value of the slider.</param>
    void ScaleSliderUpdate(float value)
    {
        objEditing.transform.localScale = new Vector3(value, value, value);
    }

    /// <summary>
    /// Finding editing object function
    /// Used to find the object that is going to be edited.
    /// </summary>
    public void FindObjectEditing()
    {
        objEditing = GetComponent<PlayerInput>().objEditing;
    }

    /// <summary>
    /// Color change function
    /// Used to change the color of an object, used in the edit menu buttons onClick().
    /// </summary>
    /// <param name="mat">Material to be changed to</param>
    public void ColorChange(Material mat)
    {

        objEditing.GetComponent<Renderer>().material = mat;
        player.GetComponent<MaterialChanger>().originalMaterial = mat;
    }
}
