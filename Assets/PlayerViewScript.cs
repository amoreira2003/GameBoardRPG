using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewScript : MonoBehaviour
{
    public GameObject EditorSwitch;
    public bool isBoolEditing = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    public bool isEditing() {
        return isBoolEditing;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
