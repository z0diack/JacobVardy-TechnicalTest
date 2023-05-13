using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private Rigidbody rb;
    GameObject objectList;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectList = GameObject.Find("Objects");
    }

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
