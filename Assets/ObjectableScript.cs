using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectableScript : MonoBehaviour
{
    
    
    public float smoothRotationSpeed = 300f;

    float ScrollIndex = 0.0f;

    public float MaximumSize = 2.0f;

    public float MinimumSize = 1.0f;

    public float ScrollIndexBase = 10.0f;

    public float ScaleIndex = 0.1f;
    public float ScaleIndexBase = 0.1f;
    

    public bool draggingLocal = false;

    PlayerViewScript playerViewScript;
    private float distance;
    void Start()
    {
        playerViewScript = Camera.main.GetComponent<PlayerViewScript>();
    }

    public void turnAround (Vector2 point, GameObject obj, float angle)
 {
     Vector3 point3 = new Vector3(point.x,point.y,0);
     Vector3 axis = new Vector3 (point.x/2,point.y/2,1);
     obj.transform.RotateAround(point3,axis,angle);
 }


        void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        playerViewScript.dragging = true;
        draggingLocal = true;
    }
 
    void OnMouseUp()
    {
        playerViewScript.dragging = false;
        draggingLocal = false;
    }
 
    void Update()
    {
        if (draggingLocal && !playerViewScript.isEditing()) {

        float scroll = Input.GetAxis ("Mouse ScrollWheel");
        if (scroll != 0.0f) {
        if(Input.GetKey(KeyCode.LeftControl)) {
        if(scroll > 0.0f) {
            ScaleIndex = ScaleIndexBase;
        } else if(scroll < 0.0f) {
            ScaleIndex = -ScaleIndexBase;
        }    
        float X = gameObject.transform.localScale.x + ScaleIndex;
        float Y = gameObject.transform.localScale.y + ScaleIndex;
        float Z = gameObject.transform.localScale.z + ScaleIndex;
        float Xresult = Mathf.Clamp(X,MinimumSize,MaximumSize);
        float Yresult = Mathf.Clamp(Y,MinimumSize,MaximumSize);
        float Zresult = Mathf.Clamp(Z,MinimumSize,MaximumSize);
        Vector3 result = new Vector3(Xresult,Yresult,Zresult);
        gameObject.transform.localScale = result;
        } else {
        if(scroll > 0.0f) {
            ScrollIndex = -ScrollIndexBase;
        } else if(scroll < 0.0f) {
            ScrollIndex = ScrollIndexBase;
        }
            turnAround(Vector2.zero,gameObject,Mathf.MoveTowards(0, ScrollIndex, smoothRotationSpeed * Time.deltaTime));
        }

        }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;

        }


    }
}
