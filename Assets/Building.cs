using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject draggingObject;

    ObjectableScript objectableScript;

    PlayerViewScript playerViewScript;
    public TileBase block;
    // Start is called before the first frame update
    Tilemap tilemap;

    public GameObject selector;
    void Start()
    {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        playerViewScript = Camera.main.GetComponent<PlayerViewScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightWindows)) && !playerViewScript.isDragging() 
        && playerViewScript.isEditing()) {
        if(Input.GetMouseButton(0)) {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tile = tilemap.WorldToCell(pos);
        tilemap.SetTile(tile,null);
        }

       if(Input.GetMouseButton(1)) {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tile = tilemap.WorldToCell(pos);
        tilemap.SetTile(tile,block);
        }
        }
        }
}
