using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditController : MonoBehaviour
{
    public Camera cam;
    GameObject itemEditing;
    GameObject player;

    [Header("Sliders")]
    public Slider widthSlider;
    public Slider heightSlider;
    public Slider scaleSlider;

    [Header("Min/Max Values")]
    public float widthMinValue;
    public float widthMaxValue;
    public float heightMinValue;
    public float heightMaxValue;
    public float scaleMinValue;
    public float scaleMaxValue;



    // Start is called before the first frame update
    void Start()
    {
        widthSlider.maxValue = widthMaxValue;
        widthSlider.minValue = widthMinValue;

        widthSlider.onValueChanged.AddListener(WidthSliderUpdate);

        heightSlider.maxValue = heightMaxValue;
        heightSlider.minValue = heightMinValue;

        heightSlider.onValueChanged.AddListener(HeightSliderUpdate);

        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;

        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(itemEditing != null)
        {
            widthSlider.value = itemEditing.gameObject.transform.localScale.x;
            heightSlider.value = itemEditing.gameObject.transform.localScale.y;
        }
    }

    void WidthSliderUpdate(float value)
    {
        itemEditing.transform.localScale = new Vector3(value, itemEditing.transform.localScale.y, value);
    }

    void HeightSliderUpdate(float value)
    {
        itemEditing.transform.localScale = new Vector3(itemEditing.transform.localScale.x, value, itemEditing.transform.localScale.z);
    }

    void ScaleSliderUpdate(float value)
    {
        itemEditing.transform.localScale = new Vector3(value, value, value);
    }

    public void findEditItem()
    {
        itemEditing = GetComponent<PlayerInput>().itemEditing;
    }

    public void ColorChange(Material mat)
    {

        itemEditing.GetComponent<Renderer>().material = mat;
        player.GetComponent<MaterialChanger>().originalMaterial = mat;
    }
}
