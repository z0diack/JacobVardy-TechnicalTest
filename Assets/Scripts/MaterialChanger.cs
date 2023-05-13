using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Camera cam;

    [Header("Material Settings")]
    public Material highlightMaterial;
    public Material originalMaterial;
    private GameObject lastHighlightedObject;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 50f, Color.blue);
        PickupCheck();
    }

    private void PickupCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10f))
        {
            if (hit.transform.gameObject.tag == "Pickupable")
            {
                GameObject hitObject = hit.collider.gameObject;
                HighlightObject(hitObject);
            }
        }
        else
            ClearHighlighted();
    }

    private void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlightedObject = gameObject;
        }

    }

    private void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }
}
