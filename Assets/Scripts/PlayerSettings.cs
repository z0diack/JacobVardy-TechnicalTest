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
    float playerGravity;

    GameObject player;

    [Header("Min/Max values")]
    public float speedMin;
    public float speedMax;
    public float jumpMin;
    public float jumpMax;


    [Header("Input Fields")]
    public Slider jumpHeight;
    public Slider speed;

    [Header("Text Fields")]
    public Text jumpText;
    public Text speedText;

    void Start()
    {
        player = GameObject.Find("Player");
        playerSpeed = player.GetComponent<PlayerInput>().movementSpeed;
        playerJumpHeight = player.GetComponent<PlayerInput>().jumpHeight;
        playerGravity = player.GetComponent<PlayerInput>().gravity;

        speed.value = playerSpeed;
        speed.minValue = speedMin;
        speed.maxValue = speedMax;
        speed.onValueChanged.AddListener(ChangeSpeed);

        jumpHeight.value = playerJumpHeight;
        jumpHeight.minValue = jumpMin;
        jumpHeight.maxValue = jumpMax;
        jumpHeight.onValueChanged.AddListener(ChangeJumpHeight);
    }

    void Update()
    {
        speedText.text = speed.value.ToString();
        jumpText.text = jumpHeight.value.ToString();
    }



    public void ChangeSpeed(float value)
    {
        player.GetComponent<PlayerInput>().movementSpeed = value;
    }

    public void ChangeJumpHeight(float value)
    {
        player.GetComponent<PlayerInput>().jumpHeight = value;
    }
}
