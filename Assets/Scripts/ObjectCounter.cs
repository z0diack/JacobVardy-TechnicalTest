using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    [Header("Object counter settings")]
    [SerializeField]
    Transform parentObject;
    [SerializeField]
    Text textElement;

    void Update()
    {
        int objectCount = parentObject.childCount;
        if (GameObject.Find("Player").GetComponent<PlayerInput>().objPicked != null)
            objectCount += 1;
        textElement.text = objectCount.ToString();
    }
}