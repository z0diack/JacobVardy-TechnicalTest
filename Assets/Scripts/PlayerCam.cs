using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Tooltip("Sensitivity for the player")]
    public float sens = 100f;
    [SerializeField]
    Transform pos;

    [SerializeField]
    float xRotation;
    [SerializeField]
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        pos.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
