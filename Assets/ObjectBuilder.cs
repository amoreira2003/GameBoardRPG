using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using SmartDLL;

public class ObjectBuilder : MonoBehaviour
{

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
        oc = GameObject.Find("ObjectCreator");
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
 

     

    void Update() {

        
        
        if(Input.GetKeyDown(KeyCode.M)) {
            changeVisiblity();
    
        }

        if(fileExplorer.resultOK && readText) {
            path = fileExplorer.fileName;
            Debug.Log(path);
            readText = false;
        }

        if(PPUInput.text != null && IsInt(PPUInput.text) && WidthInput.text != null && IsInt(WidthInput.text) && HeightInput.text != null && IsInt(HeightInput.text) && path !=null) {
            clickButton.interactable = true;
            resultado.text = "Path:" + path + " | " + "Width:" + int.Parse(WidthInput.text) + " | " + "Height:" + int.Parse(HeightInput.text) + " | " + "PPU:" + int.Parse(PPUInput.text);
        } else {
            clickButton.interactable = false;
            resultado.text = "";
        }
    }
    
    public void onPathClick() {
        string initialDir = System.Environment.SpecialFolder.MyDocuments + "/Gameboard/";
        bool restoreDir = true;
        string Title = "Open a Texture File";
        string defExt = "png";
        string Filter = "png files (*.png)|*.png";
        fileExplorer.OpenExplorer(initialDir,restoreDir,Title,defExt,Filter);
        readText = true;
        
    }

    public void onCreateClick() {
         byte[] data = File.ReadAllBytes(path);
         Texture2D texture = new Texture2D(int.Parse(WidthInput.text), int.Parse(WidthInput.text), TextureFormat.ARGB32, false);
         texture.LoadImage(data);
         texture.name = Path.GetFileNameWithoutExtension(path);
         newSprite = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),new Vector2(0.5f,0.5f),int.Parse(PPUInput.text));  
         Vector3 transform = Camera.main.ScreenToWorldPoint(Vector3.zero);
         Vector3 result = new Vector3(transform.x,transform.y,0);
         GameObject obj = Instantiate(baseObject,result,Quaternion.identity);
         obj.name = texture.name;
         obj.GetComponent<SpriteRenderer>().sprite = newSprite;
         Vector3 boundsSize = obj.GetComponent<SpriteRenderer>().bounds.size;
         obj.GetComponent<BoxCollider2D>().size = obj.GetComponent<SpriteRenderer>().bounds.size;
         obj.GetComponent<BoxCollider2D>().offset = new Vector2(boundsSize.x/2,boundsSize.y/2) ;



        GameObject oc = GameObject.Find("ObjectCreator");
        Canvas c = oc.GetComponent<Canvas>();
        CanvasGroup cg = oc.GetComponent<CanvasGroup>();
                c.enabled = false;
                cg.alpha = 0;
                cg.interactable = false;
                isClickable = false;
    }
}
