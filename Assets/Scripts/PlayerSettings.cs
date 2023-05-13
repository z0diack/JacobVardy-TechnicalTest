using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSettings : MonoBehaviour
{
    /// <summary>
    /// Floats for variables
    /// </summary>
    float playerSpeed;
    float playerJumpHeight;

    GameObject player;

    [Header("Min/Max values")]
    [SerializeField]
    float speedMin;
    [SerializeField]
    float speedMax;
    [SerializeField]
    float jumpMin;
    [SerializeField]
    float jumpMax;


    [Header("Input Fields")]
    public Slider jumpHeight;
    public Slider speed;

    [Header("Text Fields")]
    public Text jumpText;
    public Text speedText;

    void Start()
    {
        //Gets the current settings for speed and height.
        player = GameObject.Find("Player");
        playerSpeed = player.GetComponent<PlayerInput>().movementSpeed;
        playerJumpHeight = player.GetComponent<PlayerInput>().jumpHeight;


        //Sets the min/max values for the slider, sets value to current speed.
        speed.value = playerSpeed;
        speed.minValue = speedMin;
        speed.maxValue = speedMax;
        speed.onValueChanged.AddListener(ChangeSpeed);

        //Sets the min/max values for the slider, sets value to current jump height.
        jumpHeight.value = playerJumpHeight;
        jumpHeight.minValue = jumpMin;
        jumpHeight.maxValue = jumpMax;
        jumpHeight.onValueChanged.AddListener(ChangeJumpHeight);
    }

    void Update()
    {
        //Update the text on the menu.
        speedText.text = speed.value.ToString();
        jumpText.text = jumpHeight.value.ToString();
    }


    /// <summary>
    /// Changes the speed for the player.
    /// </summary>
    /// <param name="value">Value of the speed.</param>
    public void ChangeSpeed(float value)
    {
        player.GetComponent<PlayerInput>().movementSpeed = value;
    }

    /// <summary>
    /// Changes the jump height for the player.
    /// </summary>
    /// <param name="value">Value of the jump height.</param>
    public void ChangeJumpHeight(float value)
    {
        player.GetComponent<PlayerInput>().jumpHeight = value;
    }
}
