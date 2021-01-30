using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{

    public GameObject actualObject;
    ObjectableScript actualObjectScript;
    // Start is called before the first frame update
    void Start()
    {

        actualObjectScript = actualObject.GetComponent<ObjectableScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
