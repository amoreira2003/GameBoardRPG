using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

using UnityEngine;

public class Selector : MonoBehaviour
{
    public bool isSelected = false;
    public TileBase tileBase;
    public GameObject tileBaseIcon;

    GameObject Background;
    Animator animator;
    void Start()
    {


     Background = GameObject.Find("Background");
     animator = GetComponent<Animator>();
     if(transform.childCount <= 0) {
        Instantiate(tileBaseIcon,gameObject.transform,false);
     }

    }

    public void SelectorClick() {
    Transform[] childArray = Background.GetComponentsInChildren<Transform>();
    if(GameObject.Find("Tilemap").GetComponent<Building>().selector != null) {
    GameObject.Find("Tilemap").GetComponent<Building>().selector.GetComponent<Selector>().isSelected = false;
    }
    GameObject.Find("Tilemap").GetComponent<Building>().selector = gameObject;
    GameObject.Find("Tilemap").GetComponent<Building>().block = tileBase;
    isSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool result = animator.GetBool("isSelected");
        if(isSelected) {
            animator.SetBool("isSelected",true);

        } else {
            animator.SetBool("isSelected",false);
        }
    }

}
