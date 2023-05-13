using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    public Transform parentObject;
    public Text textElement;

  

    void Update()
    {
        int objectCount = parentObject.childCount;
        if (GameObject.Find("Player").GetComponent<PlayerInput>().itemPicked != null)
            objectCount += 1;
        textElement.text = "Total objects: " + objectCount.ToString();
    }
}