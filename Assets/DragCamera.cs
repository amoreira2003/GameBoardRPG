using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{


 PlayerViewScript playerView;
 private Vector3 ResetCamera; // original camera position
 private Vector3 Origin; // place where mouse is first pressed
 private Vector3 Diference; // change in position of mouse relative to origin

 public float smoothSpeed = 0.1f;
 public float smoothRotationSpeed = 4f;
 public float minimumOrthographicSize = 2.0f;
 public float maximumOrthographicSize = 5.0f;

 public float zoomSpeed = 1.0f;

public float RotationIndex = 10f;

private float targetOrtho;

 void Start()
 {
     playerView = Camera.main.GetComponent<PlayerViewScript>();
     ResetCamera = Camera.main.transform.position;
     targetOrtho = Camera.main.orthographicSize;
 }

void Update() {
        if(!playerView.isDragging()) {
        if(Input.GetKey(KeyCode.Q)) {
            turnAround(Camera.main.transform.position,Camera.main.gameObject,Mathf.MoveTowards(0, RotationIndex, smoothRotationSpeed * Time.deltaTime));
        }

         if(Input.GetKey(KeyCode.E)) {
            turnAround(Camera.main.transform.position,Camera.main.gameObject,Mathf.MoveTowards(0, -RotationIndex, smoothRotationSpeed * Time.deltaTime));
        }

        
         float scroll = Input.GetAxis ("Mouse ScrollWheel");
         if (scroll != 0.0f) {
             targetOrtho -= scroll * zoomSpeed;
             targetOrtho = Mathf.Clamp (targetOrtho, minimumOrthographicSize, maximumOrthographicSize);
             
         }

         Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
         }
            
}
 void LateUpdate()
 {

    if(!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightWindows) || playerView.isDragging())) {
    
     if(Input.GetMouseButtonDown(0))
     {
         Origin = MousePos();
     }
     if (Input.GetMouseButton(0))
     {
         Diference = MousePos() - transform.position;
         transform.position = Origin - Diference;
     }
     if (Input.GetMouseButton(1)) // reset camera to original position
     {
         transform.position = ResetCamera;
     }
    }
 }
 // return the position of the mouse in world coordinates (helper method)
    Vector3 MousePos()
    {
     return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }  

     public void turnAround (Vector2 point, GameObject obj, float angle)
 {
     Vector3 point3 = new Vector3(point.x,point.y,0);
     Vector3 axis = new Vector3 (0,0,1);
     obj.transform.RotateAround(point3,axis,angle);
 }
}