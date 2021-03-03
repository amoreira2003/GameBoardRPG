using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using SmartDLL;

public class TileCreator : MonoBehaviour {

    public bool IsFloat(string value) {    
    float floatValue;
    return float.TryParse(value, out floatValue);
}

    public bool IsInt(string value) {    
    int floatValue;
    return int.TryParse(value, out floatValue);
}
    bool isClickable = false;

    string path;
    bool readText;
    public SmartFileExplorer fileExplorer = new SmartFileExplorer();
    public Button clickButton;
    public InputField WidthInput;
    public InputField HeightInput;

    public InputField PPUInput;

    Sprite newSprite;

    public GameObject baseObject;

    Image[] currentRenderers;
    MeshRenderer[] currentText;

    public TextMeshProUGUI resultado;
    GameObject oc; 
    Canvas c; 
    CanvasGroup cg; 

    void Start() {
        oc = GameObject.Find("TileCreator");
        c = oc.GetComponent<Canvas>();
        cg = oc.GetComponent<CanvasGroup>();
        disableVisibility();

    }     

    public void disableVisibility() {
                c.enabled = false;
                cg.alpha = 0;
                cg.interactable = false;
                isClickable = false;
    }


    public void changeVisiblity() {
            if(isClickable) {
                c.enabled = false;
                cg.alpha = 0;
                cg.interactable = false;
                isClickable = false;
            } else {
                c.enabled = true;
                cg.alpha = 1;
                cg.interactable = true;
                isClickable = true;
            }
    }
} 
 
