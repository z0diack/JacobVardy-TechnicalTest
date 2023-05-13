using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private CustomInput playerInputActions;
    private CharacterController controller;
    private Vector3 velocity;
    


    [Header("Movement Settings")]
    public float movementSpeed = 2f;
    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    private float originalSpeed;


    [Header("Ground Settings")]
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;


    [Header("Menu Settings")]
    public Canvas spawn_menu_canvas;
    public Canvas main_menu_canvas;
    public Canvas edit_menu_canvas;
    public GameObject player_options;
    public GameObject game_options;
    private bool inEditMode;

    [Header("Pickup options")]
    public Camera cam;
    public Transform pickupPosition;
    public GameObject itemPicked;
    public bool ready = true;
    public GameObject itemEditing;
    public GameObject copiedObject;


    [Header("Spawning Settings")]
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cylinderPrefab;
    public GameObject capsulePrefab;
    public Transform spawnPos;
    public Material standard;
    GameObject objectList;

    private void Start()
    {
        spawn_menu_canvas.enabled = false;
        main_menu_canvas.enabled = false;
        edit_menu_canvas.enabled = false;
        cam.GetComponent<PlayerCam>();
        objectList = GameObject.Find("Objects");

    }

    private void Update()
    {
        //MOVEMENT UPDATE
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = transform.right * inputVector.x + transform.forward * inputVector.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);

        //JUMPING UPDATE
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity *Time.deltaTime);

        //GROUND CHECKER 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        //Ray for pickup debugging
        //Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 50f, Color.red);
        if (spawn_menu_canvas.isActiveAndEnabled || main_menu_canvas.isActiveAndEnabled || edit_menu_canvas.isActiveAndEnabled)
        {
            playerInputActions.Player.Pickup.performed -= Pickup_performed;
        }else
            playerInputActions.Player.Pickup.performed += Pickup_performed;

    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        playerInputActions = new CustomInput();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.Sprint.performed += Sprint;
        playerInputActions.Player.SpawnMenu.performed += SpawnMenu;
        playerInputActions.Player.MainMenu.performed += MainMenu;
        playerInputActions.Player.Pickup.performed += Pickup_performed;
        playerInputActions.Player.Delete.performed += Delete;
        playerInputActions.Player.Edit.performed += Edit;
        playerInputActions.Player.SpawnCube.performed += SpawnCube;
        playerInputActions.Player.SpawnCapsule.performed += SpawnCapsule;
        playerInputActions.Player.SpawnCylinder.performed += SpawnCylinder;
        playerInputActions.Player.SpawnSphere.performed += SpawnSphere;
        playerInputActions.Player.Copy.performed += Copy;
        playerInputActions.Player.Paste.performed += Paste;
    }


    public void Movement_performed(InputAction.CallbackContext value)
    {
        Vector2 inputVector = value.ReadValue<Vector2>();
        Vector3 movement = transform.right * inputVector.x + transform.forward * inputVector.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.performed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Sprint(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            originalSpeed = movementSpeed;
            movementSpeed = movementSpeed + 5;
        }
    }


    public void SpawnMenu(InputAction.CallbackContext value)
    {
        if (value.performed && main_menu_canvas.enabled == false && edit_menu_canvas.enabled == false)
        {
            bool spawn_menu_active = spawn_menu_canvas.isActiveAndEnabled;
            spawn_menu_canvas.enabled = !spawn_menu_active;
            bool mouseLock = !spawn_menu_active;
            LockMouse(!mouseLock);
            cam.GetComponent<PlayerCam>().enabled = spawn_menu_active;
        }
    }

    public void MainMenu(InputAction.CallbackContext value)
    {
        if (value.performed && spawn_menu_canvas.enabled == false && edit_menu_canvas.enabled == false)
        {
            bool main_menu_active = main_menu_canvas.isActiveAndEnabled;
            main_menu_canvas.enabled = !main_menu_active;
            bool mouseLock = !main_menu_active;
            LockMouse(!mouseLock);
            cam.GetComponent<PlayerCam>().enabled = main_menu_active;
            bool pausedBool = !main_menu_active;
            Paused(pausedBool);
            player_options.SetActive(true);
            game_options.SetActive(false);
        }
    }

    private void Paused(bool tf)
    {
        if(tf == true)
            Time.timeScale = 0f;
        if(tf == false)
            Time.timeScale = 1.0f;
    }

    private void LockMouse(bool tf)
    {
        if (tf == true)
            Cursor.lockState = CursorLockMode.Locked;
        if (tf == false)
            Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !tf;
    }


    public void Pickup_performed(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if (value.performed)
        {
            if(ready == true)
                if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    if (hit.transform.gameObject.GetComponent<Pickupable>())
                    {
                        hit.transform.gameObject.GetComponent<Pickupable>().SetPickedUp(pickupPosition, true);
                        itemPicked = hit.transform.gameObject;
                        StartCoroutine(readyBoolean(0.2f));
                    }
                }
            if (ready == false)
            {
                itemPicked.GetComponent<Pickupable>().SetPickedUp(itemPicked.transform, false);
                itemPicked = null;
                StartCoroutine(readyBoolean(0.2f));
            }
        }
    }

    IEnumerator readyBoolean(float delay)
    {
        yield return new WaitForSeconds(delay);
        ready = !ready;
        
    }

    private void Delete(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if(value.performed)
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
            {
                if (hit.transform.gameObject.GetComponent<Pickupable>())
                {
                    Destroy(hit.transform.gameObject);
                }
            }
    }

    private void Edit(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if (value.performed)
        {            
            if (false == inEditMode)
            { // when entering edit mode
                if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    if (hit.transform.gameObject.GetComponent<Pickupable>())
                    {
                        inEditMode = true;
                        edit_menu_canvas.enabled = true;
                        LockMouse(false);
                        cam.GetComponent<PlayerCam>().enabled = false;

                        itemEditing = hit.transform.gameObject;
                        GetComponent<EditController>().findEditItem();
                    }
                }
            }            
            else 
            { // When exiting edit mode   
                inEditMode = false;
                edit_menu_canvas.enabled = false;
                LockMouse(true);
                cam.GetComponent<PlayerCam>().enabled = true;            
            }
        }


    }

    private void SpawnCube(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(cubePrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }
    private void SpawnCapsule(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(capsulePrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }
    private void SpawnCylinder(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(cylinderPrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }
    private void SpawnSphere(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(spherePrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }

    private void Copy(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if (value.performed)
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
                if (hit.transform.gameObject.GetComponent<Pickupable>())
                    copiedObject = hit.transform.gameObject;
    }

    private void Paste(InputAction.CallbackContext value)
    {
        if(value.performed)
            if(copiedObject != null)
            {
                copiedObject.GetComponent<Renderer>().material = GetComponent<MaterialChanger>().originalMaterial;
                GameObject newSpawn = Instantiate(copiedObject, spawnPos);
                newSpawn.transform.parent = objectList.transform;
                newSpawn.transform.position = spawnPos.transform.position;
            }
    }
}
