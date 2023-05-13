using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{

    private Rigidbody rb;
    GameObject objectList;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectList = GameObject.Find("Objects");
    }

    /// <summary>
    /// Function to set the objects picked up state.
    /// Disables gravity and is kinematic when active.
    /// Enables gravity and is not kinematic when not active.
    /// </summary>
    /// <param name="holdPos">Position to be held in.</param>
    /// <param name="tf">True/false to either set picked up or not.</param>
    public void SetPickedUp(Transform holdPos, bool tf)
    {
        if(tf == true)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.parent = holdPos;
        }
        if(tf == false)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.parent = objectList.transform;
        }
    }
}
