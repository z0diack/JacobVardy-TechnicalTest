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
    [Tooltip("Movement speed for the player")]
    public float movementSpeed = 2f;
    [Tooltip("Jump height for the player")]
    public float jumpHeight = 5f;
    [Tooltip("Gravity for the player")]
    public float gravity = -9.81f;
    private float originalSpeed;


    [Header("Ground Settings")]
    [Tooltip("Empty object for the ground check function")]
    [SerializeField]
    Transform groundCheck;
    [Tooltip("Radius for checksphere for ground check")]
    private float groundDistance = 0.4f;
    [Tooltip("Layer for ground")]
    [SerializeField]
    LayerMask groundMask;
    private bool isGrounded;


    [Header("Menu Settings")]
    [SerializeField]
    Canvas spawnMenuCanvas;
    [SerializeField]
    Canvas mainMenuCanvas;
    [SerializeField]
    Canvas editMenuCanvas;
    [SerializeField]
    GameObject playerOptions;
    [SerializeField]
    GameObject gameOptions;
    private bool inEditMode;

    [Header("Pickup options")]
    [SerializeField]
    Camera cam;
    [Tooltip("Position that objects will be picked up at")]
    public Transform pickupPosition;
    [Tooltip("Object that is picked up")]
    public GameObject objPicked;
    [Tooltip("Boolean for ready for pickup")]
    public bool ready = true;
    [Tooltip("Object that is being edited")]
    public GameObject objEditing;
    [Tooltip("Object in clipbaord")]
    public GameObject copiedObject;


    [Header("Spawning Settings")]
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cylinderPrefab;
    public GameObject pyramidPrefab;
    public Transform spawnPos;
    public Material standard;
    GameObject objectList;

    private void Start()
    {
        spawnMenuCanvas.enabled = false;
        mainMenuCanvas.enabled = false;
        editMenuCanvas.enabled = false;
        cam.GetComponent<PlayerCam>();
        objectList = GameObject.Find("Objects");

    }

    private void Update()
    {
        //MOVEMENT
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = transform.right * inputVector.x + transform.forward * inputVector.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);

        //JUMPING 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity *Time.deltaTime);

        //GROUND CHECKER
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        //Ray for pickup debugging
        //Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 50f, Color.red);

        //Toggling pickup action if menus are open
        if (spawnMenuCanvas.isActiveAndEnabled || mainMenuCanvas.isActiveAndEnabled || editMenuCanvas.isActiveAndEnabled)
        {
            playerInputActions.Player.Pickup.performed -= Pickup_performed;
        }else
            playerInputActions.Player.Pickup.performed += Pickup_performed;

    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //Subscribing to actions
        playerInputActions = new CustomInput();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.SpawnMenu.performed += SpawnMenu;
        playerInputActions.Player.MainMenu.performed += MainMenu;
        playerInputActions.Player.Pickup.performed += Pickup_performed;
        playerInputActions.Player.Delete.performed += Delete;
        playerInputActions.Player.Edit.performed += Edit;
        playerInputActions.Player.SpawnCube.performed += SpawnCube;
        playerInputActions.Player.SpawnPyramid.performed += SpawnPyramid;
        playerInputActions.Player.SpawnCylinder.performed += SpawnCylinder;
        playerInputActions.Player.SpawnSphere.performed += SpawnSphere;
        playerInputActions.Player.Copy.performed += Copy;
        playerInputActions.Player.Paste.performed += Paste;
    }

    /// <summary>
    /// Movement system 
    /// Takes input and translates to tranform on the player.
    /// </summary>
    /// <param name="value">Value for the movement input.</param>
    public void Movement_performed(InputAction.CallbackContext value)
    {
        Vector2 inputVector = value.ReadValue<Vector2>();
        Vector3 movement = transform.right * inputVector.x + transform.forward * inputVector.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Jumping system 
    /// Checks if grounded then adds velocity to player in Y direction.
    /// </summary>
    /// <param name="value">Value of key pressed.</param>
    public void Jump(InputAction.CallbackContext value)
    {
        if (value.performed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    /// <summary>
    /// Spawn Menu
    /// Enables the spawn menu and unlocks the mouse for use.
    /// </summary>
    /// <param name="value">Value of key pressed.</param>
    public void SpawnMenu(InputAction.CallbackContext value)
    {
        if (value.performed && false == mainMenuCanvas.enabled && false == editMenuCanvas.enabled)
        {
            bool spawn_menu_active = spawnMenuCanvas.isActiveAndEnabled;
            spawnMenuCanvas.enabled = !spawn_menu_active;
            //Locks/unlocks mouse
            bool mouseLock = !spawn_menu_active;
            LockMouse(!mouseLock);
            cam.GetComponent<PlayerCam>().enabled = spawn_menu_active;
        }
    }
    /// <summary>
    /// Main menu
    /// Enables the main menu, pauses the timescale and unlocks the mouse for use.
    /// </summary>
    /// <param name="value">Value of key pressed.</param>
    public void MainMenu(InputAction.CallbackContext value)
    {
        if (value.performed && false == spawnMenuCanvas.enabled   && false == editMenuCanvas.enabled)
        {
            bool main_menu_active = mainMenuCanvas.isActiveAndEnabled;
            mainMenuCanvas.enabled = !main_menu_active;
            //Locks/unlocks mouse
            bool mouseLock = !main_menu_active;
            LockMouse(!mouseLock);
            cam.GetComponent<PlayerCam>().enabled = main_menu_active;
            //Pauses the game
            bool pausedBool = !main_menu_active;
            Paused(pausedBool);
            //Sets main menu active
            playerOptions.SetActive(true);
            gameOptions.SetActive(false);
        }
    }
    /// <summary>
    /// Paused function
    /// Used to pause the timescale in the game.
    /// </summary>
    /// <param name="tf">True/False boolean for either 0f or 1f timescale.</param>
    private void Paused(bool tf)
    {
        if(true == tf)
            Time.timeScale = 0f;
        if(false ==  tf)
            Time.timeScale = 1.0f;
    }
    /// <summary>
    /// Lock mouse function
    /// Used to lock the mouse for the player.
    /// </summary>
    /// <param name="tf">True/False boolean to either lock or unlock the mouse.</param>
    private void LockMouse(bool tf)
    {
        if (true == tf)
            Cursor.lockState = CursorLockMode.Locked;
        if (false == tf)
            Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !tf;
    }

    /// <summary>
    /// Pickup System
    /// Uses raycast to hit the object wanting to be picked up and then changes the parent if picked up.
    /// Has a 0.2 second delay on being able to pickup/putdown so is not spammed.
    /// </summary>
    /// <param name="value">Value of the key pressed.</param>
    public void Pickup_performed(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if (value.performed)
        {
            if(true == ready)
                if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    if (hit.transform.gameObject.GetComponent<Pickupable>())
                    {
                        //Sets the object to the pickedup state
                        hit.transform.gameObject.GetComponent<Pickupable>().SetPickedUp(pickupPosition, true);
                        objPicked = hit.transform.gameObject;
                        //Delay
                        StartCoroutine(readyBoolean(0.2f));
                    }
                }
            if (false == ready)
            {
                objPicked.GetComponent<Pickupable>().SetPickedUp(objPicked.transform, false);
                objPicked = null;
                StartCoroutine(readyBoolean(0.2f));
            }
        }
    }

    /// <summary>
    /// Delay function for pickup
    /// Used as a delay for when a player picks up/puts down an object so is not spammed.
    /// </summary>
    /// <param name="delay">The seconds of delay as a float.</param>
    /// <returns>Returns the delay</returns>
    IEnumerator readyBoolean(float delay)
    {
        yield return new WaitForSeconds(delay);
        ready = !ready;
    }

    /// <summary>
    /// Delete function
    /// Uses a raycast and if the object is one that is pickupable then the object is deleted on press.
    /// </summary>
    /// <param name="value">value for key being pressed.</param>
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

    /// <summary>
    /// Edit function
    /// Enables the edit menu as well as gets the current object being hit by raycast so that it can be edited.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
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
                        editMenuCanvas.enabled = true;
                        LockMouse(false);
                        cam.GetComponent<PlayerCam>().enabled = false;
                        //Passed the item being hit back to the edit controller
                        objEditing = hit.transform.gameObject;
                        GetComponent<EditController>().FindObjectEditing();
                    }
                }
            }            
            else 
            { // When exiting edit mode   
                inEditMode = false;
                editMenuCanvas.enabled = false;
                LockMouse(true);
                cam.GetComponent<PlayerCam>().enabled = true;            
            }
        }


    }

    /// <summary>
    /// Spawn cube function
    /// When pressed will spawn a new cube in the spawnPos.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
    private void SpawnCube(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(cubePrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }

    /// <summary>
    /// Spawn pyramid function
    /// When pressed will spawn a new pyramid in the spawnPos.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
    private void SpawnPyramid(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(pyramidPrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }

    /// <summary>
    /// Spawn cylinder function
    /// When pressed will spawn a new cylinder in the spawnPos.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
    private void SpawnCylinder(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(cylinderPrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }

    /// <summary>
    /// Spawn sphere function
    /// When pressed will spawn a new sphere in the spawnPos.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
    private void SpawnSphere(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            GameObject newSpawn = Instantiate(spherePrefab, spawnPos);
            newSpawn.transform.parent = objectList.transform;
        }
    }

    /// <summary>
    /// Copy function
    /// Uses a raycast and if copy input is done, will copy the item and save it to be pasted.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
    private void Copy(InputAction.CallbackContext value)
    {
        RaycastHit hit;
        if (value.performed)
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
                if (hit.transform.gameObject.GetComponent<Pickupable>())
                    copiedObject = hit.transform.gameObject;
    }
    /// <summary>
    /// Paste function
    /// Uses the copied object to then spawn in the object again in the spawnPos.
    /// </summary>
    /// <param name="value">Value for key being pressed.</param>
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
