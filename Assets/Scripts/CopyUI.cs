using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyUI : MonoBehaviour
{

    public Text copyText;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerInput>().copiedObject != null)
            copyText.text = "OBJECT COPIED";

        else
            copyText.text = "";

    }
}
