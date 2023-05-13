using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyUI : MonoBehaviour
{
    [SerializeField]
    Text copyText;

    void Update()
    {
        //Updates to show if an object has been copied for not.
        if(GameObject.Find("Player").GetComponent<PlayerInput>().copiedObject != null)
            copyText.text = "OBJECT COPIED";
        else
            copyText.text = "";
    }
}
