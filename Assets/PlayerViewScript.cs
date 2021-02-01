using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewScript : MonoBehaviour {

    public bool isBoolEditing = false;
    public bool dragging;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    public bool isEditing() {
        return isBoolEditing;
    }

    public bool isDragging() {
        return dragging;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
