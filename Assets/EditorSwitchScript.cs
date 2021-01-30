﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSwitchScript : MonoBehaviour
{

    bool isEditing = false;
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    public void switchEditing() {
        if(isEditing) {
           isEditing = false;
        } else {
          isEditing = true;
    }
    Camera.main.GetComponent<PlayerViewScript>().isBoolEditing = isEditing;
    animator.SetBool("isEditing", isEditing);
    GameObject Hotbar = GameObject.Find("Background");
    Hotbar.GetComponent<Animator>().SetBool("isAvaliable",isEditing);
    
    }
}
