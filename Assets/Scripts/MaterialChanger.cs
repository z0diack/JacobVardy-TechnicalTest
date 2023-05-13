using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [Header("Material Settings")]
    [SerializeField]
    Material highlightMaterial;
    [SerializeField]
    public Material originalMaterial;
    private GameObject lastHighlightedObject;

    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 50f, Color.blue);
        HighlightCheck();
    }

    /// <summary>
    /// Highlight check function
    /// Used to check if any objects need to be highlighted, if they are then highlights if the raycast goes off the object then the original material is restored.
    /// </summary>
    private void HighlightCheck()
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

    /// <summary>
    /// Highlight function
    /// Used to highlight the objects, will save the original material for it to be changed back.
    /// </summary>
    /// <param name="gameObject">GameObject that will have the material changed.</param>
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

    /// <summary>
    /// Clear highlight function
    /// Used to clear the highlight material on the object, returns the material back to the original material.
    /// </summary>
    private void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }
}
