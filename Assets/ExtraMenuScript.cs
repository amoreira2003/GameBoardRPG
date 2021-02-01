using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMenuScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
       animator = GetComponent<Animator>();
        
    }

    public void onHover() {
        if(Camera.main.GetComponent<PlayerViewScript>().isEditing()) {
            if(!animator.GetBool("isHovering")) {
                animator.SetBool("isHovering",true);

        } else {
            if(animator.GetBool("isHovering")) {
                animator.SetBool("isHovering",false);
            }
        }
    }
    }

    public void onStopHover() {
        if(Camera.main.GetComponent<PlayerViewScript>().isEditing()) {
            if(animator.GetBool("isHovering")) {
                animator.SetBool("isHovering",false);

        } else {
            if(animator.GetBool("isHovering")) {
                animator.SetBool("isHovering",false);
            }
        }
    }
    }
}
