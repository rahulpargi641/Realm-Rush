using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    //[SerializeField] [Range(1,20)] float gridSize = 10f;
    WayPoint wayPoint;
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
        wayPoint = GetComponent<WayPoint>();
    }

    

    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

     void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();

        
        transform.position = new Vector3(Mathf.RoundToInt(wayPoint.GetGridPos().x * gridSize), 0, Mathf.RoundToInt(wayPoint.GetGridPos().y * gridSize));
      
    }

    void UpdateLabel()
    {
        

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string label = wayPoint.GetGridPos().x + "," + wayPoint.GetGridPos().y;

        textMesh.text = label;
        gameObject.name = label;
    }
}
